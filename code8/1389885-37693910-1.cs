    public static string SerializeObject<T>(T value, JsonSerializerSettings settings)
            {
                if (value == null)
                {
                    return null;
                }
                
                var dictionaryObject = new Dictionary<string, object> { { typeof(T).Name, value } };
                var jsonString = JsonConvert.SerializeObject(dictionaryObject, settings);
    
                return jsonString;
            }
    
            public static T DeserializeObject<T>(string jsonString, JsonSerializerSettings settings)
            {
                var objectValue = JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonString, settings);
                return JsonConvert.DeserializeObject<T>(objectValue.Values.First().ToString(), settings);
            }
