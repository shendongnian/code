    using System.Net;
    
    var response = System.Web.HttpContext.Current.Response;
    
    foreach( Cookie cook in response.Cookies)
    {
         // set your expiration here
         cook.Expires = DateTime.MinValue;
    }
