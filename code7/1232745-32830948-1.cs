    string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = cs;
                SqlDataAdapter adpt = new SqlDataAdapter("Select * from RegisterInfoB", con);
                DataSet ds = new DataSet();
                adpt.Fill(ds, "RegisterTable");
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    if (dr["FirstName"].ToString().Trim() == "praveen")
                    {
                        dr.Delete();
                        
                    }
                }
                adpt.Update(ds);
