    class Demo : abc
    {
        public static void Main()
        {
            System.Console.WriteLine("Hello Interfaces");
            zyx();
        }
        
        public static void zyx() {
          System.Console.WriteLine("In zyx");
        }
    
        public void xyz()
        {
            zyx();
        }
    }
    
    interface abc
    {
        void xyz();
    }
