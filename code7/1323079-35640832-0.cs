    void Main()
    {
    	var x = GetTuple();
    	Console.WriteLine($"{x.Item1} {x.Item2} {x.Item3.GetType().Name}"); // Prints "string 5 MyClass"
    }
    ....
    public Tuple<string, int, MyClass> GetTuple()
    {
    	string myString = "string";
    	int myInt = 5;
    	MyClass myClass = new MyClass();
    	return Tuple.Create(myString,myInt,myClass);
    }
