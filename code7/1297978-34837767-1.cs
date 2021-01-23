    protected void btn_vac_Click(object sender, EventArgs e)
    {
        if (TreeView1.CheckedNodes.Count > 0)
        {
           try
           {
                string insert_text = "insert into P_vaccines (V_name,P_Id,Note,[Date]) values (@vn,@p_id,@note,@Date) ";
                using(SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ConnectionString))
                using(SqlCommand com = new SqlCommand(insert_text, conn))
                {
                    com.Parameters.Add("@vn", SqlDbType.NVarChar);
                    com.Parameters.Add("@p_id", SqlDbType.Int).Value = Convert.ToInt32(Session["pa_id"]);
                    com.Parameters.Add("@note", SqlDbType.NVarChar);
                    com.Parameters.Add("@Date", SqlDbType.NVarChar).Value = DateTime.Now.ToShortDateString();
                    conn.Open();
                    foreach (TreeNode node in TreeView1.CheckedNodes)
                    {
                        com.Parameters["@vn"].Value = node.Text;
                        com.Parameters["@note"].Value = note_vac.Text.Length > 0 ? note_vac.Text : DbNull.Value;
                        com.ExecuteNonQuery();
                    }
               }
               Response.Write("<script>alert('Success!')</script>");
            }
            catch (Exception ex)
            {
    	        Response.Write("Error :" + ex.ToString());
            }
        }
    }
