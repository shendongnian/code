    public string Test(string userName, string connectionString, out string dbErrorMessage)
        {
            string result = null;
            dbErrorMessage = null;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = connection.CreateCommand();
                    cmd.Parameters.Add(new SqlParameter("@UserName", userName));
                    cmd.CommandText = "SELECT stats_best FROM Users WHERE username= @UserName";
                    result = cmd.ExecuteScalar().ToString();
                }
            }
            catch (Exception ex)
            {
                dbErrorMessage = ex.Message;
            }
            return result;
        }
