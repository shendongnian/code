    if (env.IsDevelopment())
    {
        app.UseBrowserLink();
        app.UseDeveloperExceptionPage();
    }
    else
    {
        // Handle unhandled errors
        app.UseExceptionHandler("/Home/Error");
        // Display friendly error pages for any non-success case
        // This will handle any situation where a status code is >= 400
        // and < 600, so long as no response body has already been
        // generated.
        app.UseStatusCodePagesWithReExecute("/Error/{0}"); 
    }
