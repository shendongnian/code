         if (app.WebRootPath.Contains("Development"))
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                 app.UseExceptionHandler("/Home/Error");
            }
