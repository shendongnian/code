    static void Main() {
        ArrayList a = new ArrayList() {1,2,3};
	    var b = a;
	    var c = new ArrayList(a);
	
	    a.Clear();
        Console.WriteLine(a.Count); // 0
	    Console.WriteLine(b.Count); // 0
	    Console.WriteLine(c.Count); // 3
    }
