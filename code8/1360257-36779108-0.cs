        public void Configure(IApplicationBuilder app)
        {
            app.UseIISPlatformHandler();
            app.UseRequestLocalization(new RequestCulture(new CultureInfo("es")));
            app.Run(async (context) =>
            {
                context.Response.ContentType = "text/html";
                await context.Response.WriteAsync(HtmlEncoder.Default.HtmlEncode(1000.5f.ToString("C")));
            });
        }
