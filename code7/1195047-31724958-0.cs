    Dictionary<string, string> ViewState = new Dictionary<string, string>();
    ViewState.Add("txtUnloadingPlaceSearch", "");
    string select_sql_Planning_GW = "SELECT dummy from dual where upper(dummy) LIKE :upp ";
    using (OracleConnection con = new OracleConnection(connectionString))
    {
        con.Open();
        OracleCommand cmd = new OracleCommand(select_sql_Planning_GW, con);
        cmd.Parameters.AddWithValue("upp", 
            "%" + ViewState["txtUnloadingPlaceSearch"].ToString().ToLower() + "%");
        OracleDataAdapter adapter = new OracleDataAdapter(cmd);
        DataSet dss = new DataSet();
        adapter.Fill(dss);
        GridViewPlanning.DataSource = dss.Tables[0];
    }
