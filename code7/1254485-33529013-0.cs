	public static void Main()
	{
		int? i = 2;
		Console.WriteLine( type(i) );
	}
	
	public static Type type<T>( T x ) { return typeof(T); }
