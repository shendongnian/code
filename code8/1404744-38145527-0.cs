    SqlCommand md = new SqlCommand("SPSelcsclass");//select charge,shortclass from class where class=@class  
                    md.CommandType = CommandType.StoredProcedure;
                    md.Connection = con;
                    SqlParameter paam;
                    paam = new SqlParameter("@class", "SLEEPER CLASS");
                    paam.Direction = ParameterDirection.Input;
                    paam.DbType = DbType.String;
                    **cmd.Parameters.Add(paam);**
                    con.Open();
                    SqlDataReader sdr = md.ExecuteReader();
                    while (sdr.Read())
                    {
                        lb11.Text = sdr["charge"].ToString();
                        lb2.Text = sdr["shortclass"].ToString();
                    }
