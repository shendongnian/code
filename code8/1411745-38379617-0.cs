    List<string> GetObjectsJson(string input)
	{
		int index = input.IndexOf("} {"); //Assuming no objects contain a string with this in
		if (index == -1) {
			return new List<string>() {input};
		}
		List<string> objs = GetObjects(input.Substring(index + 2));
		objs.Add(input.Substring(0, index + 1));
		return objs;
	}
