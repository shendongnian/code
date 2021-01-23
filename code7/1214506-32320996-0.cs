	private void MessageB(MessageEventArgs m)
	{
		Dictionary<string, DataType> d = m.Message.Json.GetFirstArgAs<Dictionary<string, DataType>>();
		foreach (KeyValuePair<string, DataType> item in d)
		{
			// Update AItems
		}
	}
