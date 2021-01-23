    public static void SendErrorEmails(Exception exception)
    {
    	string 
    	nl          = Environment.NewLine,
    	username    = 
    		exception.Data["Username"] != null ? exception.Data["Username"].ToString() : 
    		HttpContext.Current.Session["username"] != null ? HttpContext.Current.Session["username"].ToString() : 
    		"n/a";
    	if (string.IsNullOrEmpty(username))
    	{
    		if (HttpContext.Current.Session["user_id"].ToString() == "0")
    			username = String.Format("{0} - {1} ", HttpContext.Current.Session["AgreementId"].ToString(), HttpContext.Current.Session["EmployeeName"].ToString());
    		else
    			username = "n/a";
    	}
    	StringBuilder sb = new StringBuilder();
    	sb.AppendLine(string.Format("Exception for user: {0}{1}", username, nl));
    	sb.AppendLine(string.Format("Message: {0}{1}", exception.Message, nl));
    	sb.AppendLine(string.Format("StackTrace: {0}{1}", exception.StackTrace, nl));
    	if (exception.InnerException != null)
    		sb.AppendLine(string.Format("InnerException: {0}", exception.InnerException.ToString()));
    
    	SendEmail("Email Services Error", sb.ToString());
    }
