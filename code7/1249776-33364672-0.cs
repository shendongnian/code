    protected void search_ClickALL(object sender, EventArgs e)
    {
     using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings[ddlALL.SelectedItem.Text].ConnectionString))
     {
         conn.Open();
         SqlCommand cmd = new SqlCommand("SELECT dpCreatedDT, enStatusCH, enNotificationNoNI FROM dp_enquiry WHERE ennotificationnoni = @JobnoALL", conn);
         try
         {
             SqlParameter search = new SqlParameter();
             search.ParameterName = "@JobnoALL";
             search.Value = JobnoALL.Text.Trim();
             cmd.Parameters.Add(search);
             SqlDataReader dr = cmd.ExecuteReader();
             DataTable dt = new DataTable();
             dt.Load(dr);
             gridviewALL.DataSource = dt;
             gridviewALL.DataBind();
         }
         catch (Exception ex)
         {
             Response.Write(ex.Message);
         }
         finally
         {
             if (cmd.ExecuteScalar() == null)
             {
                 Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptkey", "<script>alert('Job Number not found!');</script>");
             }
             conn.Close();
             mpePopUpALL.Show();
         }
      }
        
    }
