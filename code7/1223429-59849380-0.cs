    public void Configure(IApplicationBuilder app, IWebHostEnvironment env){
        app.UseStatusCodePages(async context =>
                        {
                            var redirctPage = pageToRedirect(context);
                            context.HttpContext.Response.Redirect(redirctPage);
        
                        }
    ...
    }
        private string pageToRedirect(StatusCodeContext context)
        {
		    var def = "";
            if(context.HttpContext.Response.StatusCode==404){
				if (context.HttpContext.Request.Path.ToString().ToLower().Contains("/product/"))
				{
					def = "/Home/Product";
                    def += context.HttpContext.Request.QueryString;
				}
				else if (context.HttpContext.Request.Path.ToString().ToLower()=="/news")//or you can call class that load info from DB to redirect
				{
					def = "/Home/News";
                    def += context.HttpContext.Request.QueryString;
				}
				else//404 error page
					def = "/Home/Error?statusCode=" + context.HttpContext.Response.StatusCode;
			}else //other errors code
                def = "/Home/Error?statusCode=" + context.HttpContext.Response.StatusCode;
            return def;
        }
