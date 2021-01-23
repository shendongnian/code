    public static class Extensions
    {
       public static int SizeOfType(this System.Type tp) {
          return Marshal.SizeOf(tp);
       }
      public static int SizeOfObjectType(this object obj) {
          return obj.GetType().SizeOfType();
       }
    }
    
    // calling it from a method, 2 ways
    var size1 = this.GetType().SizeOfType();
    var size2 = this.SizeOfObjectType();
    var size3 = typeof(string).SizeOfType();
    var size4 = "what is my type size".SizeOfObjectType();
