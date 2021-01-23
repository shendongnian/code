    public static class DbContextExtension 
    {
        public static int ExecuteStoredProcedure(this DbContext context, string name, string parameter)
        {
            var command = context.Database.GetDbConnection().CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = name;
            var param = command.CreateParameter();
            param.ParameterName = "@p1";
            param.Value = parameter;
            command.Parameters.Add(param);
            return (int)command.ExecuteScalar();
        }
    }
