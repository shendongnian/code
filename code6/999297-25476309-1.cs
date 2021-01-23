    public static class Program
    {
        private const string Url = "http://localhost:8080/";
        public static void Main()
        {
            using (WebApp.Start(Url, ConfigureApplication))
            {
                Console.WriteLine("Listening at {0}", Url);
                Console.ReadLine();
            }
        }
        private static void ConfigureApplication(IAppBuilder app)
        {
            app.Use((ctx, next) =>
            {
                Console.WriteLine(
                    "Request \"{0}\" from: {1}:{2}",
                    ctx.Request.Path,
                    ctx.Request.RemoteIpAddress,
                    ctx.Request.RemotePort);
                return next();
            });
        }
    }
