    class MyJson
    {
     public static string SerializeObject<T>(T obj, bool ignoreBase)
     {
      var myType = typeof(T);
      var props = myType.GetProperties().ToList();
      if(ignoreBase)
      {
       props = props.FindAll(p => p.DeclaringType == myType);
      }  
      
      var x = new ExpandoObject() as IDictionary<string, Object>;
      props.ForEach(p => x.Add(p.Name, p.GetValue(obj, null)));
      
      return JsonConvert.SerializeObject(x);
     }
    }
