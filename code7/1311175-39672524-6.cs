        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.Use(async (ctx, next) => {
                var lib = new MyLib.MyClass();
                var msg = lib.GetUserAgent(ctx);
                lib.WriteToResponse(ctx, "user agent is: " + msg);
            });
        }
