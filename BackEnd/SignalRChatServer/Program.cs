using SignalRChatServer.Hubs;

namespace SignalRChatServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddCors(options => options.AddDefaultPolicy(policy => policy
                .AllowCredentials()
                .AllowAnyHeader()
                .AllowAnyMethod()
                .SetIsOriginAllowed(x => true)));
            builder.Services.AddSignalR();
            var app = builder.Build();

            app.UseHttpsRedirection();

            //app.MapControllers();

            app.UseCors();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<ChatHub>("/chathub");
            });

            app.Run();
        }
    }
}
