    JObject arac = JObject.Parse(json);
    foreach (var prop in typeof(Arac).GetProperties(BindingFlags.Static |  BindingFlags.Public))
    {
        var token = arac.GetValue(prop.Name);
        if (token != null)
        { 
            object value = token.ToObject(prop.PropertyType);
            prop.SetValue(null, value);
        }
    }
