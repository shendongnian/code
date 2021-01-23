    if (System.Configuration.ConfigurationManager.ConnectionStrings["SportsDBConnString"] != null) {
        String connString = System.Configuration.ConfigurationManager.ConnectionStrings["SportsDBConnString"].ConnectionString;
        //Do other logic here or move connString declaration outside this if
    }
    else {
        throw new Exception("Missing ConnectionString SportsDBConnString in App.config/Web.Config");
    }
        
