     public static bool setCookiesValue(Page page, string cookiesName, string cookiesValue,ref string ermsg)
            {
                if (cookiesValue.Trim().Length < 1)
                {
                    ermsg = "cookies empty";
                    return false;
                }
    
                   
                    HttpCookie clearCookies = page.Request.Cookies[cookiesName];
                    clearCookies[cookiesName] = cookiesValue;
                    clearCookies.Expires = DateTime.Now.AddDays(1d);
                    page.Response.Cookies.Add(clearCookies);
                    return true;
            }
     public static String getCookies(Page page,string cookiesName)
            {
                try
                {
                    HttpCookie GetCookies = page.Request.Cookies[cookiesName];
                    return GetCookies[cookiesName].ToString();
                }
                catch (Exception er)
                {
                   
                    return string.Empty;
                }
              
            }
