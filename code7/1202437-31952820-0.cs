    static bool IsDictionary(object obj)
    {
      if (obj == null)
        return false;
      var t = obj.GetType();
      return t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Dictionary<,>);
    }
    static object GetDictionary(object a, object b)
    {
      var t = typeof(Dictionary<,>).MakeGenericType(a.GetType(), b.GetType());
      return Activator.CreateInstance(t);
    }
