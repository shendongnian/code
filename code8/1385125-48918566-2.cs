      void CallerMethod()
      {
        MethodName(Values.Value3, Values.Value1 | Values.Value2);
      }
    
      void MethodName(Values randomValue, Values allowedValues)
      {
        if ((randomValue & (allowedValues)) != 0)
        {
          // code here
        }
      }
    
      [Flags]
      public enum Values
      {
        Value1 = 1 << 0,
        Value2 = 1 << 1,
        Value3 = 1 << 2
      }
