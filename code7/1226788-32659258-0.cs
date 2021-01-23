	public class Foo
	{
		public string blah { get; set; }
		public IFoo2 Foo2Ref { get; set; }
	}
	
	internal class Foo2 : IFoo2
	{
		public int x { get; }
		public int y { get; }
		public int z { get; }
	}
	
	public interface IFoo2
	{
		int x { get; }
	}
