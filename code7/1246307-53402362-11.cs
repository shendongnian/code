        private List<T> GetModelFromReader<T>(SqlDataReader reader) where T : new()
        {
            List<T> listModels = new List<T>();
            var modelItem = new T();
            var modelType = modelItem.GetType();
            var modelProps = modelType.GetProperties();
            while (reader.Read())
            {
               var columns = Enumerable.Range(0, reader.FieldCount)
                           .Select(reader.GetName)
                           .ToList();
                foreach (var prop in inProps)
                {
                    try
                    {
                        if (columns.Contains(prop.Name))
                        {
                            var value = reader[prop.Name];
                            if (ReferenceEquals(value, DBNull.Value))
                            {
                                value = null;
                            }                            
                            var propType = prop.PropertyType;
                            Type t = Nullable.GetUnderlyingType(propType) ?? propType;
                            value = (value == null) ? null : Convert.ChangeType(value, t);
                            prop.SetValue(modelItem, value);
                        }                       
                    }
                    catch (Exception ex)
                    { //it type not the same will try to convert to string and cast.
                      //It will work fine without this part if types are the same.
                      //I recommend that you set types properly and comment out this part
                        try
                        {
                            var strValue = reader[prop.Name].ToString();
                            var value = Convert.ChangeType(strValue, prop.PropertyType);
                            prop.SetValue(modelItem, value);
                        }
                        catch { }
                    }
                }
                listModels.Add(modelItem);
                modelItem = new T();
            }
            return listModels;
        }
