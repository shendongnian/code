     public static string UpperOrLower(string mj)
     {
         if (!mj.Any())
             return "empty";
         return char.IsUpper(mj[0]) ? "upper" : "lower";
     }
