    public class ExceptionModule : IHttpModule
        {
            public void Init(HttpApplication context)
            {
                context.Error += new EventHandler(OnError);
            }
    
            private void OnError(object sender, EventArgs e)
            {
                //write logging exception logic.
            }
    }
