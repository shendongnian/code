	public static int ThreeByteHexToSignedInt(string hex)
	{
		var val = Int32.Parse(hex, System.Globalization.NumberStyles.AllowHexSpecifier);
		
		if(val > 0xEFFFFF) // If greater than maximum postive 3 byte int
		{
			val = val - 0xFFFFFF - 1; // take the compliment
		}
		
		return val;
	}
