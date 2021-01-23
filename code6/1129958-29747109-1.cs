    private static int CalulateDistanceOneWay(Type firstType, Type secondType)
    {
      var chain = new List<Type>();
      while (firstType != typeof(object))
      {
        chain.Add(firstType);
        firstType = firstType.BaseType;
      }
      return chain.IndexOf(secondType);
    }
    // returns -1 for invalid input, distance between types otherwise
    public static int CalculateDistance(Type firstType, Type secondType)
    {
      int result = CalulateDistanceOneWay(firstType, secondType);
      if (result >= 0)
      {
        return result;
      }
      return CalulateDistanceOneWay(secondType, firstType);
    }
