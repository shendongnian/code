        private List<T> GetModelFromReader<T>(SqlDataReader reader) where T : new()
        {
            List<T> listModels = new List<T>();
            var modelItem = new T();
            var modelType = modelItem.GetType();
            var modelProps = modelType.GetProperties();
            while (reader.Read())
            {
                foreach (var prop in modelProps)
                {
                    try
                    {
                        prop.SetValue(modelItem, reader[prop.Name]);
                    }
                    catch (Exception ex)
                    { //it type not the same or empty will try to convert to string
                        try
                        {
                            var strValue = reader[prop.Name].ToString();
                            var value = Convert.ChangeType(strValue, prop.PropertyType);
                            prop.SetValue(modelItem, value);
                        }
                        catch
                       {// if conversiono failed or no such field in reader
                        // model value will stay at default  
                       }
                    }
                }
                listModels.Add(modelItem);
                modelItem = new T();
            }
            return listModels;
        }
