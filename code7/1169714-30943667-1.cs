    static void Main(string[] args
    {
         string str = "12";
         long test;
         if(str.Length <= 10 
             && long.TryParse(str, out test)
             && test >= 0)
         {
            //valid   
         }
    }
