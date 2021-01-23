    public static class DapperImplementorExt
    {
    	public static void InsertUpdateOnDuplicateKey<T>(this IDapperImplementor implementor, IDbConnection connection, IEnumerable<T> entities, int? commandTimeout = null) where T : class
    	{
    		IClassMapper classMap = implementor.SqlGenerator.Configuration.GetMap<T>();
    		var properties = classMap.Properties.Where(p => p.KeyType != KeyType.NotAKey);
    		string emptyGuidString = Guid.Empty.ToString();
    
    		foreach (var e in entities)
    		{
    			foreach (var column in properties)
    			{
    				if (column.KeyType == KeyType.Guid)
    				{
    					object value = column.PropertyInfo.GetValue(e, null);
    					string stringValue = value.ToString();
    					if (!string.IsNullOrEmpty(stringValue) && stringValue != emptyGuidString)
    					{
    						continue;
    					}
    
    					Guid comb = implementor.SqlGenerator.Configuration.GetNextGuid();
    					column.PropertyInfo.SetValue(e, comb, null);
    				}
    			}
    		}
    
    		string sql = implementor.SqlGenerator.InsertUpdateOnDuplicateKey(classMap);
    
    		connection.Execute(sql, entities, null, commandTimeout, CommandType.Text);
    	}
    }
