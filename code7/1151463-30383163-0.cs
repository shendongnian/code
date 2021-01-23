    str gaClientId, kmAnonId, mpAnonId;
    
    HttpCookieCollection cookies = Request.Cookies;
    
    //GA clientId is stored as part of the _ga cookie
    if (cookies["_ga"] != null)
    {
        string gaCookie = Request.Cookies["_ga"];
        string[] parts = gaCookie.Split('.')
        gaClientId = Strint.Format("{0}.{1}", parts[2], parts[3])
    }
    
    // KM anonId
    if (cookies["km_ai"] != null)
    {
        kmAnonId = Request.Cookies["km_ai"];
    }
    
    // for brevity, I'll omit retrieving mixpanel distinctId
    // from their cookie. You will need to serialize the value of 
    // "mp_<acesstoken>_mixpanel" to JSON and take the `distinct_id` value
    // see here: http://marcmezzacca.com/integrating-mixpanel-with-asp-net-mvc-server-side-and-javascript-client-side/
    
    Analytics.Model.Options kmCallOptions = new Options()
      .SetIntegration("all", false)
      .SetIntegration("Kissmetrics", true)
      .SetIntegration("Google Analytics", true)
      .SetContext (new Context () {
        { "ip", GetUserIP() },
        { "Google Analytics", new Dict() {
          { "clientId", gaClientId }
        } 
        },
        { "AnonymousId", kmAnonId }
      }
    });
    
    Analytics.Model.Options mpCallOptions = new Options()
      .SetIntegration("all", false)
      .SetIntegration("Mixpanel", true)
      .SetContext (new Context () {
        { "ip", GetUserIP() },
        },
        { "AnonymousId", mpAnonId }
      }
    });
    
    // Send to KM and GA
    Analytics.Client.Track(null, "Added Product", new Properties() {
        { "sku", cartItem.Sku },
        { "quantity", quantity }
    }, kmCallOptions);
    
    // Send to Mixpanel
    Analytics.Client.Track(null, "Added Product", new Properties() {
        { "sku", cartItem.Sku },
        { "quantity", quantity }
    }, mpCallOptions);
