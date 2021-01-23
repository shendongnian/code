    protected static string AppendQueryString(string key, string value)
    {
         if(!string.IsNullOrEmpty(value))
              return String.Format("&{0}={1}", key, value);
    
         return String.Empty;
    }
