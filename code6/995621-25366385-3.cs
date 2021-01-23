    protected void btnFilter_Click(Object sender, EventArgs e)
    {
      if (ddlCli.SelectedIndex > 0)
            {
                try
                {
                   
                    query = queryCli + " WHERE C.ATTR2815 = '" + ddlCli.SelectedValue + "'";
                    // create data adapter
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    // this will query your database and return the result to your datatable
                    DataSet myDataSet = new DataSet();
                    da.Fill(myDataSet);
                    lblCli.Text = myDataSet.Tables[0].Rows[0]["Client"].ToString();
                    lblCliDate.Text = myDataSet.Tables[0].Rows[0]["Onboarding Date"].ToString();
                    lblCliCont.Text = myDataSet.Tables[0].Rows[0]["Contact Information"].ToString();
                    lblCliNotes.Text = myDataSet.Tables[0].Rows[0]["Notes"].ToString();
                }
                catch (Exception ex)
                {
                    string error = ex.Message;
                }
     ScriptManager.RegisterClientScriptBlock
                            (this, typeof(System.Web.UI.Page), "MyJSFunction", "$('#upGenTaskCli').toggle();", true);
    
    }
