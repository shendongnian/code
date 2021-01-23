    public static string GetAnonymousName(this Type type)
    {
      if (!type.IsNested) return type.Name;
      return type.DeclaringType.GetAnonymousName() + "+" + type.Name;
    }
