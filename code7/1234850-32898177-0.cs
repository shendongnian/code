    public class MyModule : IHttpModule {
    
         public void Init(HttpApplication app) {
            app.PostResolveRequestCache += (src, args) => {
               if (!Sessions.CurrentUser.Authenticated) {
                    app.Context.RemapHandler(new MyHandler());
               }
            }
         }
    
         public void Dispose() { }
    }
    public class MyHandler : IHttpHandler
    {
        public bool IsReusable { get { return true; } }
        public void ProcessRequest(HttpContext ctx)
        {
            ctx.Response.ContentType = "text/plain";
            ctx.Response.Write("ACCESS DENIED");
            context.Response.End();
        }
    }
    <modules>
      <remove name="FormsAuthentication" />
      <add name="MyModule" type="MyNamespace.MyModule" />
    </modules>
    /// Remove your httpHandler web config section.
