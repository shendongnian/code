    public class RequestHttpModule : IHttpModule {
            public void Init(HttpApplication context) {
                context.BeginRequest += new EventHandler(ContextBeginRequest);
                context.EndRequest += new EventHandler(ContextEndRequest);
            }
    
            public void Dispose() { }
    
            public void ContextBeginRequest(Object sender, EventArgs e) {
                SessionManager.GetInstance().OpenSession();
            }
    
            public void ContextEndRequest(Object sender, EventArgs e) {
                SessionManager.GetInstance().DisposeCurrentSession();
            }
    }
        
