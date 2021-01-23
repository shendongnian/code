    public static Date ParseFromString(string s)
      {
         //string s = "24/12/2015";
         Regex r = new Regex(@"(\d+)[\/](\d+)[\/](\d+)");
         Match m = r.Match(s);
         if (m.Success)
         {
            return new Date(m.Groups[1], m.Groups[2], m.Groups[3]);
         }
         else
         {
             // throw exception
         }
      }
