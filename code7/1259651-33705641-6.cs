    public class SessionStateItemCollectionWithInstrumentation : ISessionStateItemCollectionWrapper
    {
        public ISessionStateItemCollection WrappedCollection { get; set; }
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
