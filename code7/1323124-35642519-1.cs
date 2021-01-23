    public abstract class ValidatableMethodAttribute : Attribute
	{
		public abstract bool IsValid();
	}
	public class MyMethodAtt : ValidatableMethodAttribute
	{
		private readonly Type _type;
		public override bool IsValid()
		{
            // Validate your class attribute type here
			return _type == typeof (MyMethodAtt);
		}
		public MyMethodAtt(Type type)
		{
			_type = type;
		}
	}
	[MyClassAtt]
	public class Mine
	{
        // This is the downside in my opinion,
        // must give compile-time type of containing class here.
		[MyMethodAtt(typeof(MyClassAtt))]
		public void MethodOne()
		{
		}
	}
