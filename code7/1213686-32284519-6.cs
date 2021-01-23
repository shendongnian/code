    public static PropertyInfo GetPropertyInfoFromPath<T>(string path)
    {
      var type = typeof(T);
      return GetPropertyInfoFromPath(type, path);
    }
    public static PropertyInfo GetPropertyInfoFromPath(Type type, string path)
    {
      var parts = path.Split('.');
      var count = parts.Count();
      if (count == 0)
        throw new InvalidOperationException("Not a valid path");
      if (count == 1)
        return GetPropertyInformation(type, parts.First());
      else
      {
         var t = GetPropertyInformation(type, parts[0]).PropertyType;
         return GetPropertyInfoFromPath(t, string.Join(".", parts.Skip(1)));
      }
    }
