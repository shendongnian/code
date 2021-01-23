	public struct S { public int I; }
	public void M(object o, int i)
	{
		// ((S)o).I = i; // DOESN'T COMPILE
		typeof(S).GetField("I").SetValue(o, i);
	}
		
	public void N()
	{
		S s = new S();
		object o = s; // create a boxed copy of s
		
		M(o, 1); // mutate o (but not s)
		Console.WriteLine(((S)o).I); // "1"
		Console.WriteLine(s.I);      // "0"
		
		M(s, 2); // mutate a TEMPORARY boxed copy of s (BEWARE!)
		Console.WriteLine(s.I);      // "0"
	}
