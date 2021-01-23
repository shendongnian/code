    public T WithConnection<T>(Func<IDbConnection, T> dbOperation)
        {
            try
            {
                using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseName"].ConnectionString))
                {
                    var result = dbOperation(connection);
                    connection.Close();
                    return result;
                }
            }
            catch (TimeoutException ex)
            {
                throw new Exception(String.Format("{0}.WithConnection() experienced a SQL timeout", GetType().FullName), ex);
            }
            catch (SqlException ex)
            {
                throw new Exception(String.Format("{0}.WithConnection() experienced a SQL exception (not a timeout)", GetType().FullName), ex);
            }
            catch (InvalidOperationException ex)
            {
                throw new Exception(String.Format("{0}.WithConnection() experienced a InvalidOperationException", GetType().FullName), ex);
            }
        }
