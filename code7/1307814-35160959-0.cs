    public class ClientInfo : IDataContainer
    {
        ...
		public object GetValue(string columnName)
		{
			switch (columnName)
			{
				case "ClientRecord":
					return ClientRecord;
				case "Summary":
					return Summary;
				case "MediaPaths":
					return MediaPaths;
			}
			return null;
		}
        ...
    }
