    protected void Button1_Click(object sender, EventArgs e)
    {    
        List<string> stud = new List<string>();         
        foreach (GridViewRow row in GridView1.Rows)
        {
            CheckBox check = (CheckBox)row.FindControl("CheckBox1");
            if (check.Checked)
            {
                stud.Add(row.Cells[1].Text);
            }    
        }
        foreach (string studadmin in stud)
        {
            try
            {
                myConnection = db.getConnection();
                SqlCommand cmd = new SqlCommand("sp_IPPLOAssign");
                cmd.Connection = myConnection;
                cmd.CommandType = CommandType.StoredProcedure;
    
                cmd.Parameters.AddWithValue("@AcadYear", lb_AcadYear.Text);
                cmd.Parameters.AddWithValue("@AcadPeriod", lb_AcadPeriod.Text);
                cmd.Parameters.AddWithValue("@IPPProjID", lb_ProjID.Text);
                cmd.Parameters.AddWithValue("@ProjSubID", "0");
                cmd.Parameters.AddWithValue("@LOLoginID", ddl_LO.SelectedValue);
                cmd.Parameters.AddWithValue("@LoginID", Session["UserID"].ToString());
                cmd.Parameters.AddWithValue("@Adminno", studadmin);
    
                myConnection.Open();
                cmd.ExecuteNonQuery();
    
                lb_Msg.Text = "Update Success.";
                lb_error.Text = "";       
            }
    
            catch (Exception ex)
            {
                share.WriteLog(ex.Message, "LOAssign.aspx", "Button1_Click()", "Error in updating LO.");
    
                lb_error.Text = "Update failed.";
                lb_Msg.Text = "";
            }
            finally
            {
                if (myConnection.State == ConnectionState.Open)
                    myConnection.Close();
                }
        }
    
        refresh_gvCompany();
        refresh_gvCurrent(); 
    }
    
    
