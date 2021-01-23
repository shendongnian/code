    // custom interface
	public interface IMyBar<T> : Bar<T>
	{
		public T Value { get; }
	}
    // extend the partial base class
	public partial abstract class BarImpl : IMyBar<Java.Lang.Double>  
	{
		public abstract Java.Lang.Double Value { get; }
	}
    // compiler generates the rest
	public partial class Foo
	{
		// COMPILE ERROR HERE. No method to override
		public override Java.Lang.Double Value 
		{
			get { /* ... */ }
		}
	}
