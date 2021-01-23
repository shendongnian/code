	[DataContract]
	public abstract class EntityBase<TSubclass> : INotifyPropertyChanged
		where TSubclass : class
	{
		private List<string> _hydratedProperties;
	
		protected EntityBase()
		{
			Init();
		}
	
		private void Init()
		{
			_hydratedProperties = new List<string>()
		}
	
		[OnDeserializing]
		private void OnDeserializing(StreamingContext context)
		{
			Init();
		}
	
		// ... rest of code here
	}
