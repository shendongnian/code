     class Program
    {
        static int num1 = 0;
        static int num2 = 0;
        public static void getnum()
        {
            Console.Write("Enter number: ");
             num1 = Int32.Parse(Console.ReadLine());
            Console.Write("Enter number: ");
             num2 = Int32.Parse(Console.ReadLine());
        }
        static void Main(string[] args)
        {
            getnum();
            
            //This is the loop.          
            do
            {
                ShowNum();
                getnum();
            } while (num1 != 00);
        }
            
        static void ShowNum()
        {            
            int sum = num1 + num2 ;
            //Here we show the Sum.
            Console.WriteLine("Sum is: " + sum.ToString());         
        }
    }
