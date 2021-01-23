    public static void Main()
    {
        Console.WriteLine();
        Console.WriteLine("GetEnvironmentVariables: ");
        foreach (DictionaryEntry de in Environment.GetEnvironmentVariables())
        {
            string teststring = de.Value;
            string testpath = String.Format("\nValue as string: ",teststring);
            Console.WriteLine(testpath);
            Console.WriteLine("\n  {0} = {1}", de.Key, de.Value);
        }
    }
