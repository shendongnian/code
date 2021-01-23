    class Program
    {
        static void Main(string[] args)
        {
            //call other methods here
            welcome();
            check();
            //....            
        }
        public static void welcome()
        {
            Console.WriteLine("Fuel Consumption Calculator "+"r/n"+"Are you using Metric 1 or Imperial 2 ?");
        }
    
    
        public static void check()
        {
            string choice;
            choice = Console.ReadLine();
            if (choice == "1")
            {
                calcmetric();
            }
            else
            {
               calcimperial();
            }
    
        }
        public static void calcmetric()
        {
        }
        public static void calcimperial()
        {
        }
    }
       
