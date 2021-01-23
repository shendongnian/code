    string sqlQuery = "SELECT * from Customer";
                    string cs = ConfigurationManager.ConnectionStrings["OLEDB"].ConnectionString;
    
                    using (SqlConnection con = new SqlConnection(cs))
                    {
                        SqlCommand cmd = new SqlCommand(sqlQuery, con);
                        con.Open();
                        gvResultsDeal.DataSource = cmd.ExecuteReader();
                        gvResultsDeal.DataBind();
    
                    }
