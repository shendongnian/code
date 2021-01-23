    if(typeof(TModel).Name.Contains("Sample"))
    { 
      if (property.PropertyType.IsGenericType && property.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
      {
         property.SetValue(model,Convert.ChangeType(control.Value, property.PropertyType.GetGenericArguments()[0]),null);
      }
      else
      {
        property.SetValue(model, Convert.ChangeType(control.Value, property.PropertyType), null);
      }
