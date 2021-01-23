    private static bool StartsWithRange(string value, char first, char last)
    {
      if (string.IsNullOrEmpty(value))
      {
        return false;
      }
      if (first > last)
      {
        throw new ArgumentException(string.Format("'{0}' shouldn't come after '{1}'.", first, last), nameof(last));
      }
      int intValue = value.ToLower()[0];
      return intValue >= first && intValue <= last;
    }
