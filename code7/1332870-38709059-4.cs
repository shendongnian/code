	public static dynamic DaynamicMap(this Source source)
	{
		if (source.X == 1)
			return Mapper.Map<Destination1>(source);
		return Mapper.Map<Destination2>(source);
	}
	Console.WriteLine(new Source { X = 1, Y = 2 }.DaynamicMap());
	Console.WriteLine(new Source { X = 2, Y = 2 }.DaynamicMap());
