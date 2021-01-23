    public static string ComputeSHA256HashOfAListOfStrings(List<string> parameters)
    {
    	var concatted = string.Join(string.Empty, parameters);
    	var byteOfConcattedString = Encoding.UTF8.GetBytes(concatted);
    	return ComputeHashSha256(byteOfConcattedString);
    }
