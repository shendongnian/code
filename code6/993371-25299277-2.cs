    public static T CastNullableEnum<T>(int value)
		{
			Type type = typeof(T);
			return (T)((object)value);
		}
		public static T SomeFunction<T>(int anyEnumValue)
		{
			Program.SouthParkCharacters? spc = new Program.SouthParkCharacters?(Program.SouthParkCharacters.Kenny);
			spc = new Program.SouthParkCharacters?(Program.CastNullableEnum<Program.SouthParkCharacters>(new int?(3)));
			spc = Program.CastNullableEnum<Program.SouthParkCharacters?>(new int?(3));
			return Program.CastNullableEnum<T>(new int?(anyEnumValue));
		}
