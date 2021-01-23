    static void Main ( string[] args )
    {
        string s1 = "MyTest";
        string s2 = new   StringBuilder().Append("My").Append("Test").ToString();
        string s3 = String.Intern(s2);
        Console.WriteLine((Object)s2 == (Object)s1); // Different references.
        Console.WriteLine((Object)s3 == (Object)s1); // The same reference.
        Console.WriteLine();
        s1 = "";
        s2 = new StringBuilder().Append("").ToString();
        s3 = String.Empty;
        string s4 = String.Intern(s2);
        Console.WriteLine((Object)s2 == (Object)s1); // The same reference.
        Console.WriteLine((Object)s3 == (Object)s1); // The same reference.
        Console.WriteLine((Object)s4 == (Object)s1); // The same reference.
        Console.WriteLine((Object)s4 == (Object)s2); // The same reference.
    }
