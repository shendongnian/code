    public async Task<T> MyMethod<T>(T obj, string value)
    {
         PropertyInfo pi = obj.GetType().GetProperty("PropertyName");
         if (pi != null)
         {
             pi.SetValue(obj, value);
         }
         await Task.Delay(1000);
         return obj;            
    }
