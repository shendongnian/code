    public class AuthorizableRouteFilterAttribute : AuthorizationFilterAttribute
    {
       public override void OnAuthorization(HttpActionContext context)
       {  
          IPrincipal principal = Thread.CurrentPrincipal;            
          /*Your authorization check here*/
          if (!principal.IsInRole("YourRole")) // or whatever check you make
          {
               context.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
               return;
          }
       }        
    }
    [HttpPost]
    [AuthorizableRouteFilter]
    public HttpResponseMessage DataAction([FromBody] DataType data)
    {
        /* Actions */
    }
