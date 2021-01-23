    protected void DataBindSearch()
    {
        DataSet ds = new DataSet();
        string strConString = ConfigurationManager.ConnectionStrings["OepdSQLConnectionString"].ConnectionString;
        SqlConnection myConnect = new SqlConnection(strConString);
        myConnect.ConnectionString = strConString;
        string strCommandText = "prcPersonalSelectedByPatientIdAppointmentSelect";
        try
        {
            SqlCommand sqlCmd = new SqlCommand(strCommandText, myConnect);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = sqlCmd;
            da.Fill(ds, "personal");
            gvAppointmentSearch.DataSource = ds;
            //Finally, all results matching the criteria will be placed into the gridview
            gvAppointmentSearch.DataBind();
            DataTable dt = new DataTable();
            da.Fill(dt);
            Session["CurrentData"] = dt;
            //Counts the number of results found
            lblResults.Text = "Results Found: " + ds.Tables.Cast<DataTable>().Sum(x => x.Rows.Count).ToString();
        }
        catch (Exception fe)
        {
            lblErrors.Text = "Error: " + fe.Message;
        }
    }
