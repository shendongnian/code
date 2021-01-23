     public static string UpperOrLower(string mj)
     {
         if (string.IsNullOrEmpty(mj))
             return "bad input";
         return char.IsUpper(mj[0]) ? "upper" : "lower";
     }
