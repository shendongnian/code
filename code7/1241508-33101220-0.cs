	public T NavigateToTab<T>(string tabName, Func<AdminConsole, T> valueFactory)
	{
		AdminConsole result = SelectOnNavElement(tabName);
		return valueFactory(result);
	}
	
