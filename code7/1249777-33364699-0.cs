    protected void search_ClickALL(object sender, EventArgs e)
    {
    	if (ddlALL.SelectedItem.Text == "ENWL")
        {
    		ShowData(ConfigurationManager.ConnectionStrings["ConHprENWL"].ConnectionString.ToString());
    	}
    	else if (ddlALL.SelectedItem.Text == "NW")
    	{
    		ShowData(ConfigurationManager.ConnectionStrings["ConHprNorthumbrian"].ConnectionString).ToString());
    	}
    }
    
    private void ShowData(string connectionstring)
    {
    	using (
           SqlConnection conn =
               new SqlConnection(connectionstring))
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
