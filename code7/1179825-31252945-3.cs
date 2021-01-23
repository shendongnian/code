        protected void ddlProjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlTasks.Items.Clear();
            int ID = 0;
            if (int.TryParse(ddlProjects.SelectedValue, out ID) {
                DataTable table = new DataTable();
                string sql = "SELECT TaskID, Name FROM ProjectTasks WHERE ProjectID = @ProjectID";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Connection = con;
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("@ProjectID", ID);
                ad.Fill(table);
                ddlTasks.DataTextField = "Name";
                ddlTasks.DataSource = table;
                ddlTasks.DataBind();
            }
            
        }
