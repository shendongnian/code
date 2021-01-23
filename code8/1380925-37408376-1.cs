    private SQLCommand AddParametersToCommand(SqlCommand command, Dictionary<string, object> parameters)
    {
        if (parameters == null || command == null)
        {
            return;
        }
        SQLCommand tempCommand = command;
        foreach (var param in parameters)
        {
            var parameter = tempCommand.CreateParameter();
            parameter.ParameterName = param.Key;
            parameter.Value = param.Value ?? DBNull.Value;
            tempCommand.Parameters.Add(parameter);
        }
        return tempCommand;
    }
