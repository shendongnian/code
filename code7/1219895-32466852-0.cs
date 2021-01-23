	public abstract class BaseList<T> : BaseList
	{
		public override Type ListType { get { return typeof(T); } }
	}
	
