    public string ConcatProperties<T>(T input, params Func<T, string>[] propertyDelegates)
    {
    	return string.Join(
            ",", 
            propertyDelegates
                .Select(p => p(input))
                .Where(s => !string.IsNullOrEmpty(s));
    }
