    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
         app.UseSession(); //outside of dev  if (env.IsDevelopment())
         ....
         }
