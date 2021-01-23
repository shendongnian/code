    public class CopyWriteList<T>
	{
		private volatile List<T> list;
		public CopyWriteList()
		{
			list = new List<T>();
		}
		public CopyWriteList(int capacity)
		{
			list = new List<T>(capacity);
		}
		public T this[int index]
		{
			get { return list[index]; }
			set { Replace(x => x[index] = value); }
		}
		public void Clear()
		{
			Replace(x => x.Clear());
		}
		public void Add(T item)
		{
			Replace(x => x.Add(item));
		}
		//Etc....
		private void Replace(Action<List<T>> action)
		{
			List<T> current;
			List<T> updated;
			do
			{
				current = list;
				updated = new List<T>(current);
				action(updated);
			} while (Interlocked.CompareExchange(ref list, updated, current) != current);
		}
		public List<T> GetSnapshot()
		{
			return list;
		}
	}
