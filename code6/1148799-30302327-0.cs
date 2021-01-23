	public class CBase<TC, LT> where TC : class, new()
	{
		protected CBase() {}
		protected static ConcurrentDictionary<object, Lazy<TC>> _instances = new ConcurrentDictionary<object, Lazy<TC>>();
		
		public static TC GetInstance(object key)
		{
			return _instances.GetOrAdd(key, k => new Lazy<TC>(() => new TC())).Value;
		}
			
		private List<LT> _items = null;
		public List<LT> Series 
		{
			get 
			{
				if (_items == null) _items = new List<LT>();
				return _items;
			}
		}
	}
	
	public class CSeriesManager : CBase<CSeriesManager, SSeries>
	{
	}
