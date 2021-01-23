    static void Main(string[] args)
    {
        int x = 0;
        do
        {
            Console.WriteLine("Enter number between 2 and 12. (0 to exit)");
            x = int.Parse(Console.ReadLine());
            if (x >= 2 && x <= 12)
            {
                Console.WriteLine("{0} is good", x);
            }
            else if(x != 0)
            {
                Console.WriteLine("{0} is not valid", x);
            }
        } while (x != 0);
    }
