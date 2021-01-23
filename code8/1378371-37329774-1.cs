	private static Dictionary<string, Unit> definedUnits = new Dictionary<string, UserQuery.Unit>();
    private Unit(string name, double conversionConstant)
    {
        Name = name;
        ConversionConstant = conversionConstant;
		
		definedUnits.Add(name, this);
    }
    public static implicit operator Unit(string name)
    {
		Unit result;
		
		return definedUnits.TryGetValue(name, out result) ? result : null;
    }
