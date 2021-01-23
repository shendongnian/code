    using (SqlConnection con = new SqlConnection("the connection string"))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Add_City";
                cmd.Parameters.Add("@CityName", SqlDbType.VarChar).Value = txtCity.Text.Trim();
                cmd.Parameters.Add("@Country", SqlDbType.Int).Value = CountryId;
                cmd.Connection = con;
                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    // lblMessage.Text = "City inserted successfully!";
                }
                catch (Exception ex)
                {
                    throw ex; // Or log or handle somehow the exception
                }
            }
