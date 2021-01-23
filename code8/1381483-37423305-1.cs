                // In a using statement, acquire the SqlConnection as a resource.
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    //
                    // Open the SqlConnection.
                    //
                    con.Open();
                    //
                    // The following code uses an SqlCommand based on the SqlConnection.
                    //
                    string d;
                    d = "did" + mission.Text;
                    int p = 0;
    
                    var command = string.Format("SELECT {0} FROM [User] WHERE Username = @name", d);
                    using (SqlCommand cBd = new SqlCommand(command, con))
                    {
                        cBd.Parameters.AddWithValue("@name", txtuser.Text);
                        p = (int)cBd.ExecuteScalar();
                    }
                }
