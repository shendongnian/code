     T ExecuteScalar<T>(string commandText, Dictionary<string,object> parameters=null )
            {
                const string connectionString = @"user id=user;password=password;server=localhost;Trusted_Connection=yes;database=db; 
                                    connection timeout=30";
    
                using (var connection = new SqlConnection(connectionString))
                {
                    using (var sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = connection;
                        sqlCommand.CommandText = commandText;
                        if (parameters!=null)
                        {
                            foreach (var parameter in parameters)
                            {
                                sqlCommand.Parameters.Add(new SqlParameter(parameter.Key, parameter.Value));
                            }
                        }
                       
                       return (T) sqlCommand.ExecuteScalar();
                    }
                }
            }
