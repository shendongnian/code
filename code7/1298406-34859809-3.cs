    public static MvcHtmlString WelcomeText(this HtmlHelper htmlHelper)
    {
        var text = string.Empty;
        var areaName = ViewContext.RouteData.Values["area"].ToString();
        
        if (areaName == "Guest")          
        { 
           text = "Hello Guest";
        }
        return new MvcHtmlString(text);
    }
