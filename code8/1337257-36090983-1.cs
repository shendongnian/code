    public static void Main(string[] args)
    {
        string string1 = ""; // it can be NULL and any word too
        string string2 = ""; // it can be NULL and any word too
        if (String.Equals((string1 ?? "").Trim(), (string2 ?? "").Trim(),StringComparison.OrdinalIgnoreCase))
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
    }
