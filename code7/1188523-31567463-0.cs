    void Bootstrapper_Initialized(object sender, Telerik.Sitefinity.Data.ExecutedEventArgs e)
    {
        if (e.CommandName == "RegisterRoutes")
        {
            RegisterRoutes(RouteTable.Routes);
        }
    }
 
