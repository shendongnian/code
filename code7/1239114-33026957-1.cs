	public static bool IsHomogenousLinq<T>(IEnumerable<T> list)
	{
		//handle null and empty lists however you want (throw ArgEx?, return false?)
		var firstElement = list.First();
		return list.All(element => element.Equals(firstElement));
	}
