	void Main()
	{
		var list = new List<A>();
		list.Add(new B());
		list.Add(new C());
	}
	
	class A { }
	class B : A { }
	class C : A { }
	
