    public void SomeMethodYouWrote()
    {
        var fullTypeOfResult = typeof(YourControllerYouMentionAbove).GetServiceControllerDecoratedType("MyMethod");
    }
    // added helper to do the work for you so the code is reusable
	public static class TypeHelper
	{
		public static Type GetServiceControllerDecoratedType(this Type classType, string methodName)
		{
			var attribute = classType.GetMethod(methodName).GetCustomAttributes(typeof(ServiceControllerResultAttribute), false).FirstOrDefault() as ServiceControllerResultAttribute;
			return attribute == null ? null : attribute.ResultType;
		}
	}
