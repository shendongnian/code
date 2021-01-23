    public static bool HasOneProperty(string json)
    {
       JObject jsonObj = JObject.Parse(json);
                    
       if (jsonObj.Count > 1)
       {
          return false;
       }
        
       return true;
    }
