    var t = parameters.GetType().GetField("parameters", BindingFlags.NonPublic | BindingFlags.Instance);
    
    if (t != null) 
    {  
         foreach (DictionaryEntry dictionaryEntry in (IDictionary)t.GetValue(parameters))
         {
            var dbType = (DbType)dictionaryEntry.Value?.GetType().GetProperty("DbType")?.GetValue(dictionaryEntry.Value);  
         }
    }
