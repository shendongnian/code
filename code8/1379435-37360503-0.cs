	public class BaseClass : ISomeInterface, ISomeOther
	{
		public int Prop1 { get; set; }
		public int Prop2 { get; set; }
		public int Prop3 { get; set; }
	}
	
	public class Derived : BaseClass
	{
		// inherits all 3 props
	}
	
	public interface ISomeInterface
	{
		int Prop1 { get; }
		int Prop2 { get; }
	}
	
	public interface ISomeOther
	{
		int Prop3 { get; }
	}
	
	public static class Program
	{
		public static void Main()
		{
			BaseClass instance1 = new BaseClass();      // IntelliSense shows all 3 props
			Derived instance2 = new Derived();          // IntelliSense shows all 3 props
			ISomeInterface instance3 = new BaseClass(); // IntelliSense shows 2 props from interface
			ISomeOther instance4 = new BaseClass();     // IntelliSense shows only Prop3
		}
	}
