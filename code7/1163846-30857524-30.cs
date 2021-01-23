    {
      "webroot": "wwwroot",
      "version": "1.0.0-*",
      "resource": [ "Certificate.pfx", "Certificate.cer", "Certificate.keys" ],
    
      "dependencies": {
        "Microsoft.AspNet.Server.IIS": "1.0.0-*",
        "Microsoft.AspNet.Server.WebListener": "1.0.0-*",
        "Microsoft.AspNet.Mvc": "6.0.0-*",
        "Microsoft.AspNet.Authentication.OAuthBearer": "1.0.0-*"
        "AspNet.Security.OpenIdConnect.Extensions": "1.0.0-*",
        "AspNet.Security.OpenIdConnect.Server": ""
      }
      // other code omitted
    }
