    public static int ReadInt()
    {
        string inputString = Console.ReadLine(); // Read the string
        int intValue;
        if (int.TryParse(inputString, out intValue)) // Try to parse the string, if it succeeds, it'll be put in intValue
        {
            return intValue;
        }
        return 0; // Invalid input, return 0 or something else
    }
