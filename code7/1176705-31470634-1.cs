     DataBaseConnection db = new DataBaseConnection();
        DataTable dt = new DataTable();
        dt = db.executeNonQuery("Your Query that retrieves all user's data goes here");
        if(dt.Rows.Count > 0)
         {
        List<string> lst = new List<string>();
        foreach(DataRow dr in dt.Rows)
        {
        lst.Add(dr["Cloumn_1"].ToString());
        lst.Add(dr["Column_2"].ToString());
        
        .
        
        .
        
        Session["YourSessionName"] = lst;
        }
         }
     
