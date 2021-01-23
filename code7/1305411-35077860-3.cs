	public static class Disposable
	{
		public static IDisposable Create(Action dispose)
		{
			if (dispose == null)
				throw new ArgumentNullException("dispose");
			return (IDisposable)new AnonymousDisposable(dispose);
		}
	
		public static IDisposable Handle<TDelegate, TEventArgs>(
			Action<TDelegate> addHandler,
			Action<TDelegate> removeHandler,
			TDelegate handler)
		{
			if (addHandler == null)
				throw new ArgumentNullException("addHandler");
			if (removeHandler == null)
				throw new ArgumentNullException("removeHandler");
			if (handler == null)
				throw new ArgumentNullException("handler");
				
			addHandler(handler);
			
			return Disposable.Create(() => removeHandler(handler));
		}
	
		public static IDisposable HandleOnce<TDelegate, TEventArgs>(
			Action<TDelegate> addHandler,
			Action<TDelegate> removeHandler,
			TDelegate handler)
		{
			if (addHandler == null)
				throw new ArgumentNullException("addHandler");
			if (removeHandler == null)
				throw new ArgumentNullException("removeHandler");
			if (handler == null)
				throw new ArgumentNullException("handler");
				
			Action<object, TEventArgs> inner =
				CreateDelegate<Action<object, TEventArgs>>(
					handler,
					typeof(TDelegate).GetMethod("Invoke"));
					
			TDelegate outer = default(TDelegate);
			
			IDisposable detach = Disposable.Create(() => removeHandler(outer));
			
			Action<object, TEventArgs> nested = (s, e) =>
			{
				removeHandler(outer);
				inner(s, e);
			};
			
			outer = CreateDelegate<TDelegate>(
				nested,
				typeof(Action<object, TEventArgs>).GetMethod("Invoke"));
			
			addHandler(outer);
			
			return detach;
		}
	
		public static TDelegate CreateDelegate<TDelegate>(object o, MethodInfo method)
		{
			return (TDelegate)(object)Delegate.CreateDelegate(typeof(TDelegate), o, method);
		}
	
		public static IDisposable Handle(
			Action<EventHandler> addHandler,
			Action<EventHandler> removeHandler,
			EventHandler handler)
		{
			return Disposable.Handle<EventHandler, EventArgs>(addHandler, removeHandler, handler);
		}
	
		public static IDisposable HandleOnce(
			Action<EventHandler> addHandler,
			Action<EventHandler> removeHandler,
			EventHandler handler)
		{
			if (addHandler == null)
				throw new ArgumentNullException("addHandler");
			if (removeHandler == null)
				throw new ArgumentNullException("removeHandler");
			if (handler == null)
				throw new ArgumentNullException("handler");
				
			EventHandler nested = null;
			IDisposable detach = Disposable.Create(() => removeHandler(nested));
			nested = (s, e) =>
			{
				detach.Dispose();
				handler(s, e);
			};
			addHandler(nested);
			return detach;
		}
	
		private sealed class AnonymousDisposable : IDisposable
		{
			private volatile Action _dispose;
	
			public AnonymousDisposable(Action dispose)
			{
				_dispose = dispose;
			}
	
			public void Dispose()
			{
				Action action = Interlocked.Exchange<Action>(ref _dispose, (Action)null);
				if (action != null)
				{
					action();
				}
			}
		}
	}
