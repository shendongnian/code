    // tries to convert a general object to double, if a defaultValue is provided, it will silently fall back to it, if not, it will throw exceptions
    public static double ToDouble(object obj, double? defaultValue = null) {
      if (obj == null || obj == "" || obj == DBNull.Value) return 0.0;
      try {
        if (obj is string)
          return double.Parse((string)obj);
        return Convert.ToDouble(obj);
      } catch {
        if (defaultValue != null) return defaultValue.Value;
        throw;
      }
    }
