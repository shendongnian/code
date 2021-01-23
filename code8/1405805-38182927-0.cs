        using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                    {
                        sqlConnection.Open();
                        using (SqlTransaction sqlTrans = sqlConnection.BeginTransaction())
                        {
                           //put your code here
                        }
                     }
