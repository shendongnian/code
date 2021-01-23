        DataTable dt = new DataTable("VisitorTable");
        dt.Columns.Add(new DataColumn("session_id", System.Type.GetType("System.String")));
        dt.Columns.Add(new DataColumn("username",   System.Type.GetType("System.String")));
        dt.Columns.Add(new DataColumn("login_time", System.Type.GetType("System.DateTime")));
        dt.Columns.Add(new DataColumn("ip_address", System.Type.GetType("System.String")));
    
        Application["visitorTable"] = dt;
