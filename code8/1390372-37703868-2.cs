    protected void DataBindSearch()
    {
        DataSet ds = new DataSet();
        string strConString = ConfigurationManager.ConnectionStrings["OepdSQLConnectionString"].ConnectionString;
        string strCommandText = "prcPersonalSelectedByPatientIdAppointmentSelect";
        using (SqlConnection myConnect = new SqlConnection(strConString))
        using (SqlCommand sqlCmd = new SqlCommand(strCommandText, connect))
        {
            try
            {
                SqlCommand sqlCmd = new SqlCommand(strCommandText, myConnect);
                sqlCmd.CommandType = CommandType.StoredProcedure;
    
                //You need to add the parameter before you call da.Fill()
                sqlCmd.Parameters.Add(new SqlParameter("@PatientNumber", /*Parameter Value*/));
    
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
    }
