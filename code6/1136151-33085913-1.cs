	public void Configuration(IAppBuilder app)
	{
		JwtSecurityTokenHandler.InboundClaimTypeMap = new Dictionary<string, string>();
        //First way using app.Use()
		var currentUri1 = "";
		app.Use((context, next) => { 
			currentUri1 = context.Request.Uri.ToString(); //Get base URL
			return next().ContinueWith(task =>
			{
				context.Response.WriteAsync(" FINISHED RETRIEVING CURRENT URL ");
			});
		});
		
        //Second way using app.Run
		var currentUri2 = "";
		app.Run((context) => { 
			currentUri2 = context.Request.Uri.ToString(); //Get base URL
			 var task = context.Response.WriteAsync("Hello world! " + context.Request.Path);
                return task;
		});
	}
