	[System.AttributeUsage(System.AttributeTargets.Property)]
	public class ProperyOrderAttribute : System.Attribute
	{
		public int Order { get; private set; }
		public ProperyOrderAttribute(int order)
		{
			this.Order = order;
		}
	}
