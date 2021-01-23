    static void Main(string[] args)
        {
            int amount = 20000;
            int choice, pin = 0, x = 0;
            Console.WriteLine("Enter your pin");
            pin = int.Parse(Console.ReadLine());
            Console.WriteLine("welcome to HSPUIC bank would you like to make a withdraw today N or Y");
            char answer = char.Parse(Console.ReadLine());
            if (answer == 'Y')
            {
                //Code that must be executed after choosing "yes" .
                Console.ReadKey();
            }
        }
