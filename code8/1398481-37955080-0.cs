    cmd.Parameters.Add(DataFactory.CreateParameter("@BalanceForward", 0));
    
    public static DbParameter CreateParameter(string name, object value)
    {
       DbParameter param = _dataFactory.CreateParameter();
       param.ParameterName = name;
       if (value == null)
          param.Value = DBNull.Value;
       else
          param.Value = value;
       return param;
    }
