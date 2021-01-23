    private List<string> GetDisplayNames(object model)
    {
      Type type = typeof(model);
      List<string> displayNames = new List<string>();
      foreach (var property in type.GetProperties())
      {
        var attributes = property.GetCustomAttributes(typeof(DisplayAttribute), true);
        if (attributes.Length == 0)
        {
          displayNames.Add(property.Name);
        }
        else
        {
          displayNames.Add((attributes[0] as DisplayAttribute).Name);
        }
      }
      return displayNames;
    }
