    public sealed class NotifyEventComparer : IEqualityComparer<PropertyChangedEventArgs>
    {
        public static readonly NotifyEventComparer Instance = new NotifyEventComparer();
        bool IEqualityComparer<PropertyChangedEventArgs>.Equals(PropertyChangedEventArgs x, PropertyChangedEventArgs y)
        {
            return x.PropertyName == y.PropertyName;
        }
        int IEqualityComparer<PropertyChangedEventArgs>.GetHashCode(PropertyChangedEventArgs obj)
        {
            return obj.PropertyName.GetHashCode();
        }
    }
	//Either use Rx to access Disposable.Create or this simple implementation will do
	public static class Disposable
	{
		public static IDisposable Create(Action dispose)
		{
			if (dispose == null)
				throw new ArgumentNullException("dispose");
	
			return new AnonymousDisposable(dispose);
		}
	
		private sealed class AnonymousDisposable : IDisposable
		{
			private Action _dispose;
			
			public AnonymousDisposable(Action dispose)
			{
				_dispose = dispose;
			}
			
			public void Dispose()
			{
				var dispose = Interlocked.Exchange(ref _dispose, null);
				if (dispose != null)
				{
					dispose();
				}
			}
		}
	}
