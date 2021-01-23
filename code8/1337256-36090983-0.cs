    static void Main(string[] args)
    {
        string string1 = ""; // it can be NULL and any word too
        string string2 = ""; // it can be NULL and any word too
        if ((string1 ?? "").Trim() == (string2 ?? "").Trim())
        {
            if (string.IsNullOrEmpty(string1)) //since the strings are equal, check one of the strings
            {
                Console.WriteLine("Both strings are null or empty & equal");
            }
            else
            {
                Console.WriteLine("Both strings have values & are equal");
            }
        }
        else
        {
            Console.WriteLine("The string are different.");
        }
    }
