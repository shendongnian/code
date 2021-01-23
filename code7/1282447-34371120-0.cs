    static void Main(string[] args)
    {
        string str1 = "foo";
        string str2 = "f";
        str2 += "oo";
        Console.WriteLine(str1 == str2); // prints true (value equality check)
        Console.WriteLine(object.ReferenceEquals(str1, str2)); // prints false (reference equality check)
    }
