    public static int InsertCustomers(string Name, string Gender, string City)
            {
                string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    string updateQuery = "Insert into tblEmployee (Name, Gender, City)" +
                        " values (@Name, @Gender, @City)";
                    SqlCommand cmd = new SqlCommand(updateQuery, con);
                    SqlParameter paramName = new SqlParameter("@Name", Name);
                    cmd.Parameters.Add(paramName);
                    SqlParameter paramGender = new SqlParameter("@Gender", Gender);
                    cmd.Parameters.Add(paramGender);
                    SqlParameter paramCity = new SqlParameter("@City", City);
                    cmd.Parameters.Add(paramCity);
                    con.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
