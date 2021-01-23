    private string GetClientIPAddress()
        {
            if (HttpContext.Current.Request.ServerVariables["HTTP_VIA"] != null)
            {
                // Let's first check for a proxy
                var ipAddresses = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].Split(',');
                return ipAddresses[0].Trim();
            }
            else if (System.Web.HttpContext.Current.Request.UserHostAddress != null
                && System.Web.HttpContext.Current.Request.UserHostAddress != string.Empty)
            {
                // If they are not using one
                return System.Web.HttpContext.Current.Request.UserHostAddress;
            }
            else
            {               
                return HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }
        }
