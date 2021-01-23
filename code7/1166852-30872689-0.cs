    internal class RenderProcessHandler : CefRenderProcessHandler
    {
        protected override void OnContextCreated(CefBrowser browser, CefFrame frame, CefV8Context context)
        {
            CefV8Value global = context.GetGlobal();
            CefV8Value func = CefV8Value.CreateFunction("magic", new V8Handler());
            global.SetValue("magic", func, CefV8PropertyAttribute.None);
            base.OnContextCreated(browser, frame, context);
        }
    }
