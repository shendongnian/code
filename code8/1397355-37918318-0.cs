    // you want to return Dictionary<String, String>  - right?
    // static - I can't see any use of "this" in the method
    public static Dictionary<string, string> CreateParameterDictionary(
      params String[] values) {
      if (null == values)
        throw new ArgumentNullException("values");
      // Required: we want at least 5 parameters
      if (values.Length < 5)
        throw new ArgumentException("Too few parameters");
      // First 5 parameters must not be null or empty
      if (values.Take(5).Any(item => String.IsNullOrEmpty(item)))
        throw new ArgumentException("First five parameters must not be null or empty");
      return values
        .Select((item, index) => new {
          index = index + 1,
          value = item
        })
        .Where(item => !String.IsNullOrWhiteSpace(item.value))
        .ToDictionary(item => "param" + item.index.ToString(),
                      item => item.value);
    }
