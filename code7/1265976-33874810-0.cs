	public static class GeneralExtensions
	{
		public static bool HasProperty(this object obj, string propertyName)
		{
			return obj.GetType().GetProperty(propertyName) != null;
		}
		public static bool HasMethod(this object objectToCheck, string methodName)
		{
			var type = objectToCheck.GetType();
			return type.GetMethod(methodName) != null;
		} 
	}
