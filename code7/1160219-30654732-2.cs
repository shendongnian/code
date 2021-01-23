    static void Main (String[] args)
    {
        int i;
        try
        {
            Console.Write (" Enter a number: ");
            i = int.parse (Console.ReadLine());
        }
        catch (Exception)
        {
            Console.WriteLine("That wasn't a number.");
            return;
        }
        // rest of your code
    }
