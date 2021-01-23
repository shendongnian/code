	public override void OnActionExecuting(ActionExecutingContext filterContext)
	{
		var actionParam = filterContext.ActionParameters;
		IPassword password = null;
		IConfirmPassword confirmPassword = null;
		string originalPassword;
		string originalConfirmPassword;
		// Remove the password from the parameters
		if (actionParam.ContainsKey("model") && actionParam["model"] != null)
		{
            // If the model doesn't implement the interface, the result
            // here will be null.
			password = actionParam["model"] as IPassword;
			confirmPassword = actionParam["model"] as IConfirmPassword;
		}
		if (password != null)
		{
			// Store the original value so it can be restored later
			originalPassword = password.Password;
			password.Password = "Removed";
		}
		if (confirmPassword != null)
		{
			// Store the original value so it can be restored later
			originalConfirmPassword = confirmPassword.ConfirmPassword;
			confirmPassword.ConfirmPassword = "Removed";
		}
		string str = Json.Encode(filterContext.ActionParameters).Trim();
		string par = string.Empty;
		if (str.Length > 2)
		{
			par = str.Substring(1, str.Length - 2).Replace("\"", string.Empty);
		}
		ActionLog log = new ActionLog()
		{
			SessionId = filterContext.HttpContext.Session.SessionID,
			UserName = (request.IsAuthenticated) ? filterContext.HttpContext.User.Identity.Name : "Anonymous",
			Controller = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName,
			Action = filterContext.ActionDescriptor.ActionName,
			ActionParameters = par,
			IsPost = request.HttpMethod.ToLower() == "post" ? true : false,
			IPAddress = request.ServerVariables["HTTP_X_FORWARDED_FOR"] ?? request.UserHostAddress,
			UserAgent = request.UserAgent,
			ActionDate = filterContext.HttpContext.Timestamp
		};
		//Store the Audit into the Database
		ActionLogContext context = new ActionLogContext();
		context.ActionLogs.Add(log);
		context.SaveChanges();
		// Restore the original values
		if (password != null)
		{
			password.Password = originalPassword;
		}
		if (confirmPassword != null)
		{
			confirmPassword.ConfirmPassword = originalConfirmPassword;
		}
		// Finishes executing the Action as normal
		base.OnActionExecuting(filterContext);
	}
