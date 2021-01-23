    private static Boolean IsIP(String value) {
      if (String.IsNullOrEmpty(value))
        return false;
      String[] items = value.Split('.');
      if (items.Length != 4)
        return false;
      return items.All(item => {
        Byte b;
        // Simplest: you may want use, say, NumberStyles.AllowHexSpecifier to allow hex as well
        return Byte.TryParse(item, out b);
      });
    }
