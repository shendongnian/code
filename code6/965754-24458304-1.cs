    public static bool NumericalEquals(object x, ulong y)
    {
      if (x == null)
        return false;
      Type type = x.GetType();
      if (type.IsEnum)
        return false;
      switch (Type.GetTypeCode(type))
      {
      case TypeCode.Byte:
        return (byte)x == y;
      ...other cases here
      default:
        return false;
      }
    }
