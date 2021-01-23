    string sql = "INSERT INTO Products (Description) Values (@Description)";
                        SqlCommand sqlCommand = new SqlCommand(sql, conn);
                        sqlCommand.Parameters.Add("@Description", SqlDbType.Varchar).Value = newDescription.SomePropertyInsideYourClass;
                        conn.Open();
                        sqlCommand.ExecuteNonQuery();
                        conn.Close();
