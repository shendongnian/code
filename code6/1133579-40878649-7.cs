    public static async Task<IEnumerable<object>> GetAnonymousResults(IUnitOfWork unitOfWork, string spName, SqlParameter[] outParameters, params SqlParameter[] parameters)
            {
                
                //meh, you only need the context here. I happened to use UnitOfWork pattern and hence this.
                var context = unitOfWork as DbContext;
        
                DbCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = spName;
                command.Connection = context.Database.Connection;
        
                command.Parameters.AddRange(parameters);
        
                //Forget this if you don't have any out parameters
                command.Parameters.AddRange(outParameters);
        
                try
                {
                    command.Connection.Open();
                    var reader = await command.ExecuteReaderAsync();
                    return reader.ToObjectList();
                }
                finally
                {
                    command.Connection.Close();
                }
            }
 
