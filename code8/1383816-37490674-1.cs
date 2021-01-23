    private SqlParameter[] GetSPParams()
    {
        var spParams = new List<SqlParameter>();
        int loopNum = 1;
        while (ParamExists(loopNum))
        {
            spParams.Add(new SqlParameter()
            {
                ParameterName = GetParamName(loopNum),
                SqlDbType = GetSqlDbType(loopNum),
                Value = GetParamValue(loopNum)
            });
        }
        return spParams.ToArray();
    }
