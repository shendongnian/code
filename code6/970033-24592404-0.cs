    public void ProcessQuery(string tableName, params MySqlParameter[] sqlParams)
    {
        using(MySqlConnection cn = new MySqlConnection(this.ConnectionString))
        using(MySqlCommand cmd = cn.CreateCommand())
        {
            //produce comma delimited list of param names with leading @ stripped eg. Param1, Param2, Param3
            string columnNameStr = string.Join(", ", sqlParams.Select(sqlParam => sqlParam.ParameterName.Substring(1)));
            //produce comma delimited list of param eg. @Param1, @Param2, @Param3
            string valueParamStr = string.Join(", ", sqlParams.Select(sqlParam => sqlParam.ParameterName));
            string sql = string.Format("INSERT INTO {0} ({1}) VALUES ({2})",
                tableName,
                columnNameStr,
                valueParamStr);
            cmd.CommandText = sql;
            cmd.Parameters.AddRange(sqlParams);
        }
    }
