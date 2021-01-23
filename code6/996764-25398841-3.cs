	public static void Test()
	{
		Gen<Parent> foo = new Gen<Parent>(new Parent(5));
		Gen<Child> bar = new Gen<Child>(new Child(5));
		Gen<Child> bas = new Gen<Child>(new Child(6));
		if (foo == bar)
			Console.WriteLine ("equal");
		else
			Console.WriteLine ("not-equal");
		if (foo == bas)
			Console.WriteLine ("equal");
		else
			Console.WriteLine ("not-equal");
	}
