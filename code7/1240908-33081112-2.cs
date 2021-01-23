    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter your name: ");
            string s = Console.ReadLine();
            Console.WriteLine("Your name: " + s);
            Console.Write("Enter your surname: ");
            // change here
            string surname = Console.ReadLine();
            Console.WriteLine("Your surname: " + surname);
            Console.ReadLine();
        }
    }
