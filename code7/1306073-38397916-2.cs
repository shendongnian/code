      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseBrowserLink();
      }
      else
      {
        app.UseExceptionHandler(builder =>
          {
            builder.Run(async context =>
            {
              context.Response.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;
              context.Response.ContentType = "text/html";
              var error = context.Features.Get<Microsoft.AspNetCore.Diagnostics.IExceptionHandlerFeature>();
              if (error != null)
              {
                LogException(error.Error, context);
                await context.Response.WriteAsync("<h2>An error has occured in the website.</h2>").ConfigureAwait(false);
              }
            });
          });
      }
