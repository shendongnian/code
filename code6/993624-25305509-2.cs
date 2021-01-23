    public static bool Equals(object a, object b)
    {
         try
         {
             return ((int)a).equals((int)b);
         }
         catch
         {
             return a.Equals(b);
         }
    }
