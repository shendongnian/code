    public static bool Is83(string fileName)
    {
    	var parts = Path.GetFileName(fileName).Split('.');
    	return parts.Length == 2 && parts[0].Length <= 8 && parts[1].Length <= 3;
    }
