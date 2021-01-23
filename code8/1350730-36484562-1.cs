    class Foo
    {
    	public int Bar { get; set; }
    }
    
    var source = new List<Foo>();
    bool test1 = !source.Any() || source.All(e => e.Bar == 0);
    bool test2 = source.All(e => e.Bar == 0);
    bool test3 = !source.Any(e => e.Bar == 0);
    Debug.Assert(test1 == test2 && test2 == test3);
