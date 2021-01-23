     static void Main(string[] args)
        {
            int okay;
            Console.WriteLine("Enter a number:");
            if (Int32.TryParse(Console.ReadLine(), out okay))
            {
                Multiplication(okay);
            }
            else
            {
                Console.WriteLine("Invalid Number");
            }
            Console.ReadKey();
        }
        static void Multiplication(int number)
        {
            int value = 10;
            for (int mult = 2; mult <= value; mult++)
            {
                Console.Write("{0} * {1} = {2} \n", number, mult, number * mult);
            }
        }
