          protected void Application_Start()
          {
            string query = "your query";
             ///Typically you would have some sort of datalayer
            SqlConnection sqlConn = new SqlConnection(conSTR);
            sqlConn.Open();
            SqlCommand cmd = new SqlCommand(query, sqlConn);
            
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            sqlConn.Close();
            ///Create Stat object
            Stats stat = new Stats();
            stat.startDate = dt.Columns["startDate"];
           //etc
           Session["stats"] = stat;
    }
