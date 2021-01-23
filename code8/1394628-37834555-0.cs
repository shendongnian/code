     public class ReadOnlyModule : IHttpModule
        {
            public void Init(HttpApplication context)
            {
                context.PreRequestHandlerExecute += (_o, _e) =>
                {
                    var handler = ((HttpApplication)_o).Context.CurrentHandler;
    
                    var page = handler as Page;
                    if (page != null)
                    {
                        page.PreRender += (o, e) =>
                        {
                            var readonlyPropertyInfo = o.GetType().GetProperty("IsReadonly");
                            var shouldMakeItReadonly = readonlyPropertyInfo != null && (bool)readonlyPropertyInfo.GetValue(o) == true;
                            var isEnable = !shouldMakeItReadonly;
                            EnableControls(((Page)o).Controls, isEnable);
                        };
    
                    }
                };
            }
    
            public void EnableControls(ControlCollection ctrl, bool isEnable)
            {
                foreach (Control item in ctrl)
                {
                    if (item.HasControls())
                        EnableControls(item.Controls, isEnable);
                    else if (item is WebControl)
                        ((WebControl)item).Enabled = isEnable;
                    else if (item is HtmlControl)
                        ((HtmlControl)item).Disabled = !isEnable;
                }
            }
    
            public void Dispose()
            {
    
            }
        }
