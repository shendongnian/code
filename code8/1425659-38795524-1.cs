        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(LogLevel.Debug);
            app.UseFileServer();
            app.UseWebSockets();
            app.UseSignalR<RawConnection>("/raw-connection");
            app.UseSignalR();
        }
