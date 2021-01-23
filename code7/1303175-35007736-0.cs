	public class WeakReferences<T>
	{
		private Func<string, T> _factory;
	
		public WeakReferences(Func<string, T> factory)
		{
			_factory = factory;
		}
	
		private Dictionary<string, WeakReference> _references =
			new Dictionary<string, WeakReference>();
	
		public T this[string index]
		{
			get
			{
				T target = default(T);
				if (_references.ContainsKey(index))
				{
					var wr = _references[index];
					target = (T)wr.Target;
					if (wr.IsAlive)
					{
						Console.WriteLine("Reused: " + index);
						return target;
					}
				}
				target = _factory(index);
				_references[index] = new WeakReference(target);
				return target;
			}
		}
	}
