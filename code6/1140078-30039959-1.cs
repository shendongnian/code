	private static List<string> GetDifferent(Dictionary<string, object> currentValues, Dictionary<string, object> previousValues)
	{
		var changed = currentValues
			          .Where(k => previousValues.Any(p => p.Key == k.Key && !AreValueEquals(k.Value, p.Value)))
			          .Select(k => k.Key);
		return changed.ToList();
	}
	
