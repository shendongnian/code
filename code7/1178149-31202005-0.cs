    public static MvcHtmlString LoggedInMessage(this HtmlHelper htmlHelper, IPrincipal user)
    {
        var tb = new TagBuilder("span");
        if (user.Identity.IsAuthenticated)
	    {
		   if(user.IsInRole("Admin"))
		   {
	        	tb.SetInnerText("Admin Login Successfull");
		   }
		   else if(user.IsInRole("OtherRole"))
		   {
	        	tb.SetInnerText("User Login Successfull");
		   }  
	    }
        return new MvcHtmlString(tb.ToString());
    }
