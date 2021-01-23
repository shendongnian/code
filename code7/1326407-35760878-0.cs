    public static string storedProcName = "NameOfSomeStoredProc";
    public string ConnString
    {
    	get { return ConfigurationManager.ConnectionStrings["DbConn2"].ConnectionString; }
    }
    
    public string UserConnName
    {
    	get { return string.Concat(ConfigurationManager.AppSettings["userConnName"], storedProcName); }
    
    }
