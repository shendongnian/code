    Action action = () => { MethodToBePassed(); };
    
      public static void MethodToBePassed()
      {
      }
    
       public static void Test(string a, Action action)
       {
          action();
       }
