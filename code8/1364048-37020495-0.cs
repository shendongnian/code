    internal static void SetValue(object lifetimeManagerKey, object value)
    {
      Dictionary<object, object> dictionary = UnityPerRequestHttpModule.GetDictionary(HttpContext.Current);
      if (dictionary == null)
      {
        dictionary = new Dictionary<object, object>();
        HttpContext.Current.Items[UnityPerRequestHttpModule.ModuleKey] = (object) dictionary;
      }
      dictionary[lifetimeManagerKey] = value;
    }
