	public static string InnerXml(this XElement self)
	{
		var reader = self.CreateReader();
		reader.MoveToContent();
		return reader.ReadInnerXml()?.Trim();
	}
