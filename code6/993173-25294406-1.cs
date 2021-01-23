    // Server
    using System.Security.Claims;
    using System.Security.Principal;
    using Microsoft.AspNet.SignalR;
    public class AuthorizeClaimsAttribute : AuthorizeAttribute
    {
        protected override bool UserAuthorized(IPrincipal user)
        {
            var principal = user as ClaimsPrincipal;
            return principal != null && principal.HasClaim("Token", "value");
        }
    }
    [HubName("stockTicker")]
    [AuthorizeClaims]
    public class StockTickerHub : Hub
    {
        // ...
    }
    // Client
    var handler = new HttpClientHandler();
    handler.CookieContainer = new CookieContainer();
    using (var httpClient = new HttpClient(handler))
    {
        httpClient.DefaultRequestHeaders.Add("Token", "a TOKEN GOES HERE.. blah");
        await httpClient.GetAsync(url + "/login");
    }
    objConnection.CookieContainer = handler.CookieContainer;
    IHubProxy proxy = objConnection.CreateHubProxy("stockTicker");
    await objConnection.Start();
