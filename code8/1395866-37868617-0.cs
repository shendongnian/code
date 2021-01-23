	private static string a = "a";
	private static string b = "b";
    public string Property1 { get; } = a + b;
    public string Property2 => a + b;
    Console.WriteLine(Property1 == Property2);   // true, since "ab" == "ab"
    a = "no more a";
    Console.WriteLine(Property1 == Property2);   // false, since "ab" != "no more ab"
