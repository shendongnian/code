    public class WebApiSessionModule : IHttpModule
    {
        protected virtual void OnPostAuthorizeRequest(object sender, EventArgs e)
        {
            HttpContext context = HttpContext.Current;
    
            if (this.IsWebApiRequest(context))
            {
                context.SetSessionStateBehavior(System.Web.SessionState.SessionStateBehavior.ReadOnly);
            }
        }
    }
