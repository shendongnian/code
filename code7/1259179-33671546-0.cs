	public class MyBaseClass
	{
		public MyBaseClass(SomeEnum enumValue, User user)
		{
		}
	}
	public class MyDerivedClass : MyBaseClass
	{
		public MyDerivedClass(SomeEnum enumValue, User user, CustomClass customStuff)
			: base(enumValue, user)
		{
		}
	}
