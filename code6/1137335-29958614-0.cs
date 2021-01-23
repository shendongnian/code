    string cisconn = ConfigurationManager.ConnectionStrings["CTaC_Information_System.Properties.Settings.CIS_beConn"].ConnectionString;
    
    using (OleDbConnection conn = new OleDbConnection(cisconn))
    {
        conn.Open();
        //Create your commands or do your SQL here.
    }
