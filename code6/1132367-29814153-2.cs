    public T ConvertModel<T>(T obj) 
    {
       var dic = new Dictionary<string,object>();
       foreach (var prop in obj.GetType().GetProperties())
       {
          dic.Add(prop.Name, prop.GetValue(obj,null));
       }
