    public static bool Equals(object a, object b)
    {
         try
         {
             var aint = (int)a;
             var bint = (int)b;
             return aint.equals(bint);
          }
         return a.Equals(b);
    }
