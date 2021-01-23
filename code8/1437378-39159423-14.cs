	class Record
	{
		...
		
		public bool IsXmlRootLoaded
		{
			bool isLoaded = false;
			try
			{
				isLoaded = XmlFormatID.HasValue && XmlFormat != null;
			}
			catch(ObjectDisposedException ex)
			{
				isLoaded = false;
			}
			return isLoaded;
		}
	}
