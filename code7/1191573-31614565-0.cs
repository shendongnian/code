	public enum Format{XML,JSON}
	public abstract class Foo
	{
		public abstract Format Format { get; }
	}
	public class JsonFoo : Foo
	{
		public override Format Format
		{
			get { return Format.JSON; }
		}
	}
	public class XmlFoo : Foo
	{
		public override Format Format
		{
			get { return Format.XML; }
		}
	}
