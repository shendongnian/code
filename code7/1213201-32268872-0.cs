      public Dictionary<String, String> queryOptions = new Dictionary<String, String>();
    
      ...
    
      Boolean isFirst = true;
    
      // providing that "value" is StringBuilder
      foreach(var pair in queryOptions) {
        if (isFirst) 
          isFirst = false;
        else
          value.Append(',');
    
        //TODO: what is "isArray" in the context of String?
        if (isArray(pair.Value)) { 
          //TODO: implementing format output will be better
          value.Append(pair.Key);
          value.Append(':');
          value.Append(pair.Value);
        }
        else {
          //TODO: implementing format output will be better
          value.Append(pair.Key);
          value.Append(':');
          value.Append('\'');
          value.Append(pair.Value);
          value.Append('\'');
        }
      }
