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
                    using (SqlCommand cmd = new SqlCommand(command, con))
                    {
                        cmd.Parameters.AddWithValue("@name", txtuser.Text);
                        p = (int)cmd.ExecuteScalar();
                    }
                    command = string.Format("UPDATE [User] SET {0} = @par WHERE Username = @name", d);
                    using (SqlCommand cmd = new SqlCommand(command, con))
                    {
                        cmd.Parameters.AddWithValue("@par", p);
                        cmd.Parameters.AddWithValue("@name", txtuser.Text);
                        cmd.ExecuteNonQuery();
                    }
                }
