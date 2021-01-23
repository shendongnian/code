	public class MyEntity : IIdentifiable<Guid>
	{
		public Guid Id { get; set; }
	}
	
	public class MyOtherEntity : MyEntity, IIdentifiable<int>
	{
		int IIdentifiable<int>.Id { get; set; }
	}
	
	var foo = new MyClass<MyOtherEntity>(); // So, which IIdentifiable should be used?
