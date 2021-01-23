    PropertyInfo subPropertyInfo = apptObject.GetType().GetProperty("Person");
    Object p = subPropertyInfo.GetValue(apptObject);
    
    PropertyInfo subSubPropertyInfo = p.GetType().GetProperty("Name");
    subSubPropertyInfo.SetValue(p, replacementValue, null);
