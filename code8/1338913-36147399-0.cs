    void Application_PreRequestHandlerExecute(object sender, EventArgs e)
        {
            HttpApplication application = (HttpApplication)sender;
            HttpContext context = application.Context;
    
                if (context.Handler is Page)
                {
                    Page page = (Page)context.Handler;
                    page.Load += ...
                }
            }
        }
