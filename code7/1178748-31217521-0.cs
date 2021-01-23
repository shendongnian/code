    protected void btnSubmit_Click(object sender, EventArgs e)
            {
                //connection
                string query = "select * from tablename where Projectname like "+ddlProjectName.SelectedValue+"%";// this is an sample query change as per your requirement
                 SqlDataAdapter da = new SqlDataAdapter(query,connection);
                 DataTable dt = new DataTable();
                 da.Fill(dt);
                 grdData.DataSource =dt;
                 grdData.DataBind(); 
            }
