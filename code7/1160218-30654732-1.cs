    static void Main (String[] args)
    {
        int i;
        Console.Write (" Enter a number: ");
        bool result = int.TryParse(Console.ReadLine(), out i);
        if (result)
        {
            // your normal code
        }
        else
        {
            Console.WriteLine("That wasn't a number.");
        }
    }
