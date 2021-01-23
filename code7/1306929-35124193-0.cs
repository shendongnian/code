    DataTable dt;
    void Application_Start(Object s, EventArgs e)
    {
        dt= new DataTable();
        dt.Columns.Add(new DataColumn("session_id", System.Type.GetType("System.String")));
        dt.Columns.Add(new DataColumn("username",   System.Type.GetType("System.String")));
        dt.Columns.Add(new DataColumn("login_time", System.Type.GetType("System.DateTime")));
        dt.Columns.Add(new DataColumn("ip_address", System.Type.GetType("System.String")));
        Application["visitorTable"] = dt;
    }
