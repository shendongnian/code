                public static List<object> ToObjectList(this IDataReader dataReader, bool ignoreUnmappedColumns = true)
                {
                    var list = new List<object>();
                    while (dataReader.Read())
                    {
                        IEnumerable<string> columnsName = dataReader.GetColumnNames();
                        var obj = new ExpandoObject() as IDictionary<string, object>;
        
                        foreach (var columnName in columnsName)
                        {
                            obj.Add(columnName, dataReader[columnName]);
                        }
                        var expando = (ExpandoObject)obj;
        
                        list.Add(expando);
                    }
        
                    return list;
                }
           
        
