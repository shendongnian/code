     class C
     {
       // no references to A at class level
 
       int MethodUsingA()
       {
          // use A here
       }
       int MethodTryingToUseA()
       {
          try 
          {
            return MethodUingA(); // will throw loader error 
                                  // during JIT if A assembly is missing 
          }
          catch // use specific exception, LoaderException?
          {
            return 42; // JIT of MethodUingA failed
          }
     }
