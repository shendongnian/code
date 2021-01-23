	public static void Main()
	{
		string str = "6,2"; // float with decimals from europe
		Console.WriteLine(mytesttype(str).GetType());
		str = "6232";
		Console.WriteLine(mytesttype(str).GetType());
		str = "6String";
		Console.WriteLine(mytesttype(str).GetType());
	}
	
	static object mytesttype(string str) {
	
		int i;
		float f;
		if (int.TryParse(str,out i)) return i;
		if (float.TryParse(str, out f)) return f;
		return str;
	
	}
