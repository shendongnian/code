    var result = new List<string>();
    var type = eContentField.GetType();
    foreach (var prop in type.GetProperties())
    {
         result.Add(prop.Name);
     }
     return result.ToArray();
    }
    
