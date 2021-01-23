    public static bool NumericalEquals(object x, ulong y)
    {
      if (x == null)
        return false;
      switch (Type.GetTypeCode(x.GetType())
      {
      case TypeCode.Byte:
        return (byte)x == y;
      ...other cases here
      default:
        return false;
      }
    }
