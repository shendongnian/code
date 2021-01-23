    static void Main(string[] args)
    {
        string name = null, surname = null;
        while (surname != "A")
        {
            Console.WriteLine("Enter Name:");
            name = Console.ReadLine(); // Point A
            if (name == "A")
            {
                break;
            }
            Console.WriteLine("Enter Surname:");
            surname = Console.ReadLine(); // Point B
        }
        Console.WriteLine("Oops");
        Console.ReadLine();
    }
