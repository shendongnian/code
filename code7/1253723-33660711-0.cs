    static void Main(string[] args)
    {
        TestQuery();
    }
    private static void TestQuery()
    {
        using (var ctx = new ProductContext())
        {
            var parameter = new SqlParameter("@ID", 1);
            var commandText = "select * from product where ProductId = @ID";
            Action a = () =>
            {
                IDbCommand command = new SqlCommand();
                command.CommandText = commandText;
                command.Parameters.Add(parameter);
                command.Connection = ctx.Database.Connection;
                if (command.Connection.State != ConnectionState.Open)
                {
                    command.Connection.Open();
                }
                var reader = command.ExecuteReader();
                try
                {
                    throw new Exception();
                    while (reader.Read())
                    {
                        var pId = reader["ProductID"];
                    }
                    reader.Close();
                }
                catch (Exception exc)
                {
                    //for simplification, we just swallow this error, but in reality the connection error
                    //would reach the IDbExecutionStrategy, and would do a retry. Instead we fake the retry
                    //with a loop below
                }
                finally
                {
                    reader.Dispose();
                    //command.Parameters.Clear();  <--------- THIS LINE IS MISSING FROM EF
                    command.Dispose();
                }
            };
            for (int i = 0; i < 2; i++) // we fake the retry with a loop now
            {
                a();
            }
        }
    }
