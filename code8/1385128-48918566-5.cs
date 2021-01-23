          [Flags]
          public enum Values
          {
            Value1 = 1 << 0,
            Value2 = 1 << 1,
            Value3 = 1 << 2
          }    
  
          void MethodName(Values randomValue)
          {
            if (IsValid(randomValue, Values.Value1 | Values.Value2))
            {
              // code here
            }
          }
        
          bool IsValid(Values randomValue, Values allowedValues)
          {
            return ((randomValue & (allowedValues)) != 0);
          }
