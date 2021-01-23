	public static void Main()
	{
		var x = new List<int>();
		x.Add(1);
		Add(x, 2);
		Console.WriteLine(x.Count.ToString()); // will print "2";
		AddRef(ref x, 3);
		Console.WriteLine(x.Count.ToString()); // will print "1";
		Add3(x, 1, 2, 3 );
		Console.WriteLine(x.Count.ToString()); // will also print "1";
		Add3Ref(ref x, 1, 2, 3 );
		Console.WriteLine(x.Count.ToString()); // will print "3";
	}
	
	private static string Changestring(string s)
    {
        return s.Trim();
    }
	
	
    static void Add(List<int> list, int value)
    {
        list.Add(value);
    }
    static void AddRef(ref List<int> list, int value)
    {
        list = new List<int>(); // same as the s += “Hi”; in the question
        list.Add(value);
    }
    static void Add3(List<int> list, int value1, int value2, int value3)
    {
        list = new List<int>(); // same as the s += “Hi”; in the question
        list.Add(value1);
        list.Add(value2);
        list.Add(value3);
    }
	
	static void Add3Ref(ref List<int> list, int value1, int value2, int value3)
    {
        list = new List<int>(); // same as the s += “Hi”; in the question
        list.Add(value1);
        list.Add(value2);
        list.Add(value3);
    }
