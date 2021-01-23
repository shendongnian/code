    if(prop.PropertyType.GetGenericTypeDefinition() == typeof(ObservableStateCollection<>))
    {                        
         MethodInfo m = prop.PropertyType.GetMethod("GetAll");
         var collection = m.Invoke(prop.GetValue(model, null), null);
                        
         foreach (var e in (IEnumerable)collection)
         {
             \\act on item in collection                      
         }
    }
