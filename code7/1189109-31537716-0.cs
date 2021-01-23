    public static IObjectType ConvertJsonToClass(string jsonString)
    {
      IObjectType obj;
      try{
        obj = JsonConvert.DeserializeObject<Person>(jsonString);
      }
      catch{
        try{
          obj = JsonConvert.DeserializeObject<Bird>(jsonString);
        }
        catch{ obj = null; }
      }
      return obj;
    }
