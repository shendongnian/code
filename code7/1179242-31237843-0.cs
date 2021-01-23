    Issue model = deserializeObject<Issue>(result);
    public T deserializeObject<T>(string result)
            {
                try
                {
                    var settings = new JsonSerializerSettings
                    {
                        Formatting = Formatting.Indented,
                        NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore,
                        DefaultValueHandling = DefaultValueHandling.Ignore
                    };
                    var items = (T)JsonConvert.DeserializeObject(result, typeof(T), settings);
    
                    return items;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
    
                }
    
            }
