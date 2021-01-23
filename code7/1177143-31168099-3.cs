    public override void ExecuteResult(ControllerContext context)
    {
    	if (context == null)
    	{
    		throw new ArgumentNullException("context");
    	}
    	if (this.JsonRequestBehavior == JsonRequestBehavior.DenyGet &&
                                string.Equals(context.HttpContext.Request.HttpMethod,
                                              "GET",
                                              StringComparison.OrdinalIgnoreCase))
    	{
    		throw new InvalidOperationException(MvcResources.JsonRequest_GetNotAllowed);
    	}
    	HttpResponseBase response = context.HttpContext.Response;
    	if (!string.IsNullOrEmpty(this.ContentType))
    	{
    		response.ContentType = this.ContentType;
    	}
    	else
    	{
    		response.ContentType = "application/json";
    	}
    	if (this.ContentEncoding != null)
    	{
    		response.ContentEncoding = this.ContentEncoding;
    	}
    	if (this.Data != null)
    	{
    		JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
    		if (this.MaxJsonLength.HasValue)
    		{
    			javaScriptSerializer.MaxJsonLength = this.MaxJsonLength.Value;
    		}
    		if (this.RecursionLimit.HasValue)
    		{
    			javaScriptSerializer.RecursionLimit = this.RecursionLimit.Value;
    		}
    		response.Write(javaScriptSerializer.Serialize(this.Data));
    	}
    }
