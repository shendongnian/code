    public T CastNullableEnum<T>(int value) 
	{
		var enumType = Nullable.GetUnderlyingType(typeof(T));
		if (Enum.IsDefined(enumType, value)) 
		{
			return (T)(object)Enum.Parse(enumType, value.ToString());
		}
		return default(T);
	}
    var test1 = CastNullableEnum<SouthParkCharacters?>(3); 
    //returns Kenny
    
    var test2 = CastNullableEnum<SouthParkCharacters?>(9); 
    // returns null
