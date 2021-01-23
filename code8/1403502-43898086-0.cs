    {
        static void Main(string[] args)
        {
            int fact = 1; 
            Console.Write("Enter a number to find factorial:");
            int n = int.Parse(Console.ReadLine());
            for (int i = n; i > 0; i--)
            {
                fact = fact * i;
            }
            Console.Write("Factorial of" + n +"is :"+fact);
            Console.ReadLine();
        }
    }
}
