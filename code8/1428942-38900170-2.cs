	public class ServiceControllerResultAttribute : Attribute
	{
		public ServiceControllerResultAttribute(Type someType)
		{
			this.ResultType = someType;
		}
		public Type ResultType { get; set; }
	}
