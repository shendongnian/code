    public void ListStatusOptions()
    {
        // Query, vars and debug info removed
        conn.Open();
        SqlDataAdapter dataAdapter = new SqlDataAdapter(strSQLQuery, conn);
        DataSet ds = new DataSet();
        dataAdapter.Fill(ds, "StatusOptions");
    
        int varArrCount = ds.Tables[0].Rows.Count;
    
        var arrStatusOption = new StatusOption[varArrCount];
        int i = 0;
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            arrStatusOption[i] = new StatusOption
                                     {
                                         Name = dr["StatusValue"].ToString(),
                                         IsSelected = false
                                     }
            i++;
        }
        conn.Close();
    }
