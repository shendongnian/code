    var context = HttpContext.Current;
    var cookieName = "Country";
    var ip = context.Request.UserHostAddress;
    
    if (!string.IsNullOrWhiteSpace(ip) && ip != "127.0.0.1")
    {
        //If the cookie is present (means cookie is set already) then return
        if (context.Request.Cookies[cookieName] != null)
        {
            return;
        }
    
        string countryName;
    
        using (var client = new WebServiceClient(xxxxx, "xxxxxxxx"))
        {
            var ipCountry = client.Country(ip);
            countryName = ipCountry.Country.Name;
        }
    
        context.Response.Cookies.Add(new HttpCookie(cookieName)
        {
            Value = countryName,
            Expires = DateTime.Now.AddDays(365)
        });
    
        switch (countryName)
        {
            case "Denmark":
                context.Response.Redirect("/");
                break;
            case "United Kingdom":
                context.Response.Redirect("/en");
                break;
            case "Germany":
                context.Response.Redirect("/de");
                break;
            case "Sweden":
                context.Response.Redirect("/se");
                break;
            case "Norway":
                context.Response.Redirect("/no");
                break;
            default:
                //context.Response.Redirect("http://www.google.com");
                break;
        }
    }
    else if (loadedArgs.pageview.Area.ID != 2)
    {
        context.Response.Redirect("/choose-country");
    }
