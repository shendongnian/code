    [WebMethod]
        public string[] GetCompletionList(string prefixText)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ToString());
                con.Open();
                SqlCommand cmd = new SqlCommand("select Company_name from Outword_CommonMST where Company_name  " +
                                                                "like '" + prefixText + "%' order by company_name", con);
                //cmd.Parameters.AddWithValue("@Name", prefixText);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable  dt = new DataTable( );
                da.Fill(dt);
                List<string> Company_name = new List<string>();
                for(int i=0;i<dt.Rows.Count;i++)
                {
                    Company_name.Add(dt.Rows[i][0].ToString());
                }
                return Company_name.ToArray();
            }
        }
