    public string GetPhysicalTempFolder()
    {
        return AppDomain.CurrentDomain.BaseDirectory + @"Temp\";
    }
    
    private string GetVirtualTempFolder()
    {
        //Returns ~/Temp/
        if (Url != null)                
            return System.Web.HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) + Url.Content("~/Temp/");
        else
            return VirtualPathUtility.ToAbsolute("~/Temp/");
    }
