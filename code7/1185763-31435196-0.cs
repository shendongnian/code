    public static JToken FindToken<T>(string key, T value)
    {
         string serialized = NewtonsoftJsonSerializer.Instance.Serialize(value);
         var jObject = JObject.Parse(serialized);
         var jToken = jObject.SelectToken(key);
    
         if(jToken != null)
              return jToken;
    
         return null;
    }
