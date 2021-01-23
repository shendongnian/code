	public interface ITypeAny
	{
		string MyCommonProperty { get; set; }
	}
	public interface ITypeA : ITypeAny
	{
		string AAA { get; set; }
	}
	public interface ITypeB : ITypeAny
	{
		string BBB { get; set; }
	}
	public abstract class TypeAny : ITypeAny
	{
		public string MyCommonProperty { get; set; }
	}
	public class TypeA : TypeAny, ITypeA
	{
		public string AAA { get; set; }
	}
	public class TypeB : TypeAny, ITypeB
	{
		public string BBB { get; set; }
	}
