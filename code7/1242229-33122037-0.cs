            var clientIP = (System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"]==null) ? System.Web.HttpContext.Current.Request.UserHostAddress:
                               System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            IPAddress addr = IPAddress.Parse(clientIP);
            IPHostEntry entry = Dns.GetHostEntry(addr);
            var clientDomainName = entry.HostName;
