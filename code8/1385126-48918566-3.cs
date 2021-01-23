    [Flags]
    public enum Values
    {
      Value1 = 1 << 0,
      Value2 = 1 << 1,
      Value3 = 1 << 2
    }
    void MethodName(Values randomValue)
    {
      if ((randomValue & (Values.Value1 | Values.Value2)) != 0)
      {
        // code here
      }
    }
