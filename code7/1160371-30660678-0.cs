    private static Dictionary<Type, object> = new Dictionary<Type, object>
    {
      { typeof(int), -1 },
      { typeof(string), string.Empty },
      { typeof(DateTime), DateTime.MinValue },
    }
    public T GetCookie<T>(string key)
    {
        object value;
        if (defaultValues.TryGetValue(typeof(T), out value)
        {
          return (T)value;
        }
        return default(T);
    }
