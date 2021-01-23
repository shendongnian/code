                List<string> tutionfees = new List<string>();
                using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
                {
                    SqlDataAdapter da = new SqlDataAdapter("select * from fees where admno = @admno", cnn);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "fees");
    
    
                    foreach (DataRow row in ds.Tables["fees"].Rows)
                    {
                        tutionfees.Add(row["tutionfee"].ToString());
                    }
                }
