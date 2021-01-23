	static IEnumerable<MyEnum> GetFlags(MyEnum input)
	{
		return Enum.GetValues(typeof(MyEnum)).Cast<MyEnum>()
           .Where(f => input.HasFlag(f));
	}
