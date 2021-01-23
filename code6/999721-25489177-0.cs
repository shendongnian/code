    protected void Application_Start(object sender, EventArgs e)
    {
    SqlDependency.Start(ConfigurationManager.ConnectionStrings["pubsConnectionString"].ConnectionString);
    }
 
