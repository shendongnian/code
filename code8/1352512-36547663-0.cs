    public static T CreateTable<T>(IDictionary<string, object> values) where T: ITable, new()
    {
         var table = new T();
         foreach (var propInfo in typeof(T).GetProperties())
         {
              if (values.ContainsKey(propInfo.Name))
              {
                   propInfo.SetValue(table, values[propInfo.Name]);
              }
         }
         return table; //note that any property not defined in the dictionary will be initialized to the field's type default value.
    }
