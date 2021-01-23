    // get the config file for this application
    Configuration config = ConfigurationManager.OpenExeConfiguration( ConfigurationUserLevel.None );
    
    // set the new values
    config.ConnectionStrings.ConnectionStrings["Connection Name"].ConnectionString = "Connection String Value";
    
    // save and refresh the config file
    config.Save( ConfigurationSaveMode.Minimal );
    ConfigurationManager.RefreshSection( "connectionStrings" );
