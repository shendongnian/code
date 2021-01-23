    static void Main(string[] args)
    {
        // Get the users input.
        Console.WriteLine("Enter the FIRST Integer.");
        string a = Console.ReadLine();
        Console.WriteLine("Enter the SECOND Integer.");
        string b = Console.ReadLine();
        // Variables, in which we will store the parsed strings that user passes.
        int integerA;
        int integerB;
        // Try to parse the strings that user passes to create two integer numbers.
        // If either parse of a or parse of b fail, then the method Int32.TryParse()
        // will return false and the code in the body of if, will not be executed.
        if(Int32.TryParse(a, out integerA) && Int32.TryParse(b, out integerB))
        {
            // Pass the integers to the methods called swap
            Swap(ref integerA, ref integerB);
            Console.WriteLine("The integers have been swapped!");
            Console.WriteLine("The FIRST INTEGER is now " + int1);
            Console.WriteLine("The SECOND INTEGER is now " + int2);
        }
        Console.WriteLine();
    }
    // This methods makes the actual swap
    static void Swap(ref int a, ref int b)
    {
        int temp = a;
        a = b;
        b = temp;
    }
