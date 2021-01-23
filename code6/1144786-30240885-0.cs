    private sealed class _Placeholder : INotifyCollectionChanged, IEnumerable
    {
    	public event NotifyCollectionChangedEventHandler CollectionChanged;
    
    	public IEnumerator GetEnumerator() { throw new NotImplementedException(); }
    }
	static void Test(object obj)
	{
		if ((obj is INotifyCollectionChanged) && (obj is IEnumerable))
		{
			var typeObject = obj.GetType();
			// Retrieve the delegate for another type
			Action<_Placeholder> _DoSomething = SomeExtensions.DoSomething<_Placeholder>;
			// Retrieve the generic definition
			var infoTemp = _DoSomething.Method.GetGenericMethodDefinition();
			// Retrieve the MethodInfo for our object's type
			var method = infoTemp.MakeGenericMethod(typeObject);
			// Call the extension method by invoking
			method.Invoke(null, new[] { obj });
			//If you can return the delegate, you can try the following:
			//var typeDelegate = typeof(Action<>).MakeGenericType(typeObject);
			//var action = Delegate.CreateDelegate(typeDelegate, method);
			//((Action<_Test>)action)(obj as _Test);
		}
	}
