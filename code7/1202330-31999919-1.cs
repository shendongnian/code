    public class CustomAuthorize : System.Web.Http.AuthorizeAttribute
    {
        HttpRequestMessage request = actionContext.ControllerContext.Request;
        string token = string.Empty;
        if (request.Headers.GetValues("token-name") != null)
        {
            token = request.Headers.GetValues("token-name").FirstOrDefault().ToString();
            IAppStateService appService; //<--- I've created a custom service tier class for appstate stuff
            //Get appState instance, however makes sense for you.
            //I'm using repo pattern with UnitOfWork, so mine looks like this...
            //"IContainer ioc = DependencyResolution.IoC.Initialize();"
            //"IAppStateService appService = ioc.GetInstance<IAppStateService>();"
            appService.SetHttpApplicationState(HttpContext.Current.Application);
            bool isAuthorized = appService.CheckTokenAndDoStuff(token);
            //inside that method ^^^ you'll do stuff like
            //"_appState.Lock();"
            //"if (_appState[token] == null) return false" (or whatever)
            //"_appState.Unlock();"
        }
        if (isAuthorized)
        {
            HttpResponseMessage resp = request.CreateResponse(HttpStatusCode.OK);
            resp.Headers.Add("AuthenticationToken", token);
            resp.Headers.Add("WWW-Authenticate", "Basic");
            resp.Headers.Add("AuthenticationStatus", "Authorized");
        }
        return isAuthorized;
    }
