    static class Program
    {
        static void Main()
        {
            int i = "124241".ParseToInt();       //124241
            int j = DateTime.Now.ParseToInt();   //-1
         }
    
         public static int ParseToInt(this object testItem)
         {
            int i;
            return Int32.TryParse(testItem.ToString(), out i) ? i : -1;
         }
    }
