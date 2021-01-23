    public static class IQueryableExtensions
        {
    
            /// <summary>
            /// Shows the sql the IQueryable query will be generated into and executed on the DbServer
            /// </summary>
            /// <param name="query">The IQueryable to analyze</param>
            /// <param name="decodeParameters">Set to true if this method should try decoding the parameters</param>
            /// <remarks>This is the generated SQL query in use for Entity Framework</remarks>
            public static string ShowSql(this IQueryable query, bool decodeParameters = false)
            {
                var objectQuery = (ObjectQuery)query; 
               
                string result = ((ObjectQuery)query).ToTraceString();
    
                if (!decodeParameters)
                    return result; 
    
                foreach (var p in objectQuery.Parameters)
                {
                    string valueString = p.Value != null ? p.Value.ToString() : string.Empty;
                    if (p.ParameterType == typeof(string) || p.ParameterType == typeof(DateTime))
                        valueString = "'" + valueString + "'";
                    result = result.Replace("@" +p.Name, p.Value != null ? valueString : string.Empty); 
                }
                return result; 
            }     
    
    }
