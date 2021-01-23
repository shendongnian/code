    protected override void OnActionExecuting(ActionExecutingContext filterContext)
    {
      HttpClient httpClient = new HttpClient();
      string baseUrl = "http://localhost:60477/";
      dynamic token = Session["token"];
    
      if (token.AccessToken != null)
      {
        httpClient.DefaultRequestHeaders.Add(
            "Authorization",
            string.Format("Bearer {0}", token.AccessToken)
        );
    
        httpClient.BaseAddress = new Uri(baseUrl);
      }
      
      if(filterContext.ActionParameters.ContainsKey("httpClient"))
      {
        filterContext.ActionParameters["httpClient"] = httpClient;
      }
      else
      {
        // error
      }
      base.OnActionExecuting(filterContext);
    }
