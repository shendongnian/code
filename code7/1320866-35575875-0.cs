    public class myClass
    {
        public myClass(string input)
        {
             var ar = input.Split(',');
             if (ar.Length > 2)
             {
                 A = ar[0];
                 B = ar[1];
             }
        }
    
        public string A { get; set; }
        public string B{ get; set; }
        //and so on
    }
