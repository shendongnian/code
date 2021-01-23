    private string AppendParameter(string query, string parameterName, string parameterValue, SqlParameterCollection parameters)
    {
         if (string.IsNullOrEmpty(parameterValue))
             query += "Field1 IS NULL ";
         else
         {
             query += "Field1 = " + parameterName + " ";
             parameters.AddWithValue(parameterName, parameterValue);
         }
         return query;
    }
