        static int ReadInput(string message)
        {
            int n = 0;
            do
            {
                Console.WriteLine(message);
            }
            while (!int.TryParse(Console.ReadLine(), out n));
            return n;
        }
        static void Main(string[] args)
        {
            int i = ReadInput("Enter a Number");
            if (i % 2==0) 
            {
                Console.WriteLine("even");
            }
            else if(i%2!=0)
            {
                Console.WriteLine("odd");
                //enter code here
            }
        }
    }
