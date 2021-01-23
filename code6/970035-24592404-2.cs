	public void ProcessQuery(string tableName, MySqlParameter keyParam, params MySqlParameter[] sqlParams)
    {
        using(MySqlConnection cn = new MySqlConnection(this.ConnectionString))
        using(MySqlCommand cmd = cn.CreateCommand())
        {
			/*Update Statement*/
			
			//Param1 = @Param1, Param2 = @Param2, @Param3 = @Param3, etc.
			string updateParamStr = string.Join(
				", ", 
				sqlParams.Select(sqlParam => string.Format("{0} = {1}", sqlParam.ParameterName.Substring(1), sqlParam.ParameterName)));
			
			//param = @param
			string keyMatchStr = string.Format("{0} = {1}", 
		        keyParam.ParameterName.Substring(1),
				keyParam.ParameterName);
			
			string updateSql = string.Format("UPDATE {0} SET {1} WHERE {2}",
				tableName,
				updateParamStr,
			    keyMatchStr);	
			
			
			/*Insert Statement*/
			
            //produce comma delimited list of param names with leading @ stripped eg. Param1, Param2, Param3
            string columnNameStr = string.Join(", ", sqlParams.Select(sqlParam => sqlParam.ParameterName.Substring(1)));
            //produce comma delimited list of param eg. @Param1, @Param2, @Param3
            string valueParamStr = string.Join(", ", sqlParams.Select(sqlParam => sqlParam.ParameterName));
            string insertSql = string.Format("INSERT INTO {0} ({1}) VALUES ({2})",
                tableName,
                columnNameStr,
                valueParamStr);
			
			
			/*Combined Update and Insert*/
			string combinedSql = string.Format("{0} {1} WHERE ROW_COUNT() = 0", updateSql, insertSql);
			
            cmd.CommandText = combinedSql;
			cmd.Parameters.Add(keyParam);
            cmd.Parameters.AddRange(sqlParams);
            cn.Open();
            cmd.ExecuteNonQuery();
        }
    }
