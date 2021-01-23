    protected void Application_Start(object sender, EventArgs e)
    {
        RegisterRoutes(RouteTable.Routes);
    }
    
    
    public static void RegisterRoutes(RouteCollection routes)
    {
         routes.MapPageRoute("", "news/{id}", "~/News.aspx");
    }
