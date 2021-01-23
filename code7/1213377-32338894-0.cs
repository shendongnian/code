    public class TemplateModule : IHttpModule
    {
        protected static string _arg1;
        protected static string _arg2;
        public void Init(HttpApplication context)
        {
            _arg1 = "~/";
            _arg2 = "0";
            context.BeginRequest += new EventHandler(ContextBeginRequest);
        }
        // ...
    }
