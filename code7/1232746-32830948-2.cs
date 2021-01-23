    string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = cs;
                    string firstName= "praveen"; // this data will get from calling method
                    SqlDataAdapter adpt = new SqlDataAdapter("Select * from RegisterInfoB", con);
                    DataSet ds = new DataSet();
                    adpt.Fill(ds, "RegisterTable");
                    string deleteQuery = string.Format("Delete from RegisterInfoB where FirstName = '{0}'", firstName);
                    SqlCommand cmd = new SqlCommand(deleteQuery, con);
                    adpt.DeleteCommand = cmd;
                    con.Open();
                    adpt.DeleteCommand.ExecuteNonQuery();
                    con.Close();
