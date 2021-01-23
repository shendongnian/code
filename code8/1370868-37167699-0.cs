        protected override void Application_BeginRequest(object sender, EventArgs e)
		{
            base.Application_BeginRequest(sender, e);
            var urlpath = HttpContext.Current.Request.Url.PathAndQuery; //Modify this based on condition
            if(<condition>)
                Context.RewritePath(<updatedpath>);
        }
