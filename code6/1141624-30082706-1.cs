    public static List<T> ExecuteQuery<T>(string qry, List<Tuple<string, OdbcType, object>> parameters = null)
    ...
    ...
    foreach (var parameter in parameters)
    {
        command.Parameters.Add(parameter.Item1, parameter.Item2).Value = parameter.Item3;
    }
