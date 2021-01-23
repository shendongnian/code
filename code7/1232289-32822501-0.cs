    void Print(object value, string propertyName)
    {
        if (property.PropertyType == typeof(string) || property.PropertyType.IsPrimitive)
        {
          sbAllNotes.AppnedLine(.. propertyName .. value ..);
        }
        else if ((typeof(IEnumerable).IsAssignableFrom(property.PropertyType)
        {
          PrintCollectioType((IEnumerable)value);
        }
        else
        {
          PrintComplexType(value);
        }
    }
    
    void PrintCollectioType(IEnumerable collection)
    {
      foreach (var item in collection) 
      {
        Print(item, "Collection Item");
      }
    }
    
    void PrintComplexType(IEnumerable collection)
    {
      foreach(var property in owner.GetType().GetProperties())
      {
        var propertyName = property.Name;
        var propertyValue = property.GetValue(owner);
        Print(item, propertyName);
      }
    }
