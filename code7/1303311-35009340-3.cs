    class SimpleClass
    {
       public static readonly long A = IdentityHelper.GetExpensiveResult().A;
       public static readonly long B = IdentityHelper.GetExpensiveResult().B;
    
       static SimpleClass()
       {
       }
    }
