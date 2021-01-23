    	public class SessionStateItemCollectionWrapper : ISessionStateItemCollection
		{
			private readonly ISessionStateItemCollection _wrappedCollection;
			public SessionStateItemCollectionWrapper(ISessionStateItemCollection wrappedCollection)
			{
				_wrappedCollection = wrappedCollection;
			}
			//...
			//...
			//...
			public object this[string name]
			{
				get
				{
					LogRead();
					return _wrappedCollection[name];
				}
				set
				{
					LogWrite();
					_wrappedCollection[name] = value;
				}
			}
			//...
			//More log on some methods
			//...
		}
