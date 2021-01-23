    			var results = conn.Query<dynamic>(sql, param);
    			var resultSet = new List<SerializableDictionary<string, object>>();
    			foreach (IDictionary<string, object> row in results)
    			{
    				var dict = new SerializableDictionary<string, object>();
    				foreach (var pair in row)
    				{
    					dict.Add(pair.Key, pair.Value);
                    }
    				resultSet.Add(dict);
    			}
