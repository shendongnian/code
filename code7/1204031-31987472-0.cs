    public static string MyMethod(string format, params object[] args)
    {
      if (format == null || args == null)
        throw new ArgumentNullException(format == null ? "format" : "args");
      return string.Format((IFormatProvider) null, format, args);
    }
