	public abstract class BaseList<T> : BaseList, IList<T>
	{
		public override Type ListType { get { return typeof(T); } }
		
		// Delegate IList<T> implementation to the base class
		
		public new IEnumerator<T> GetEnumerator()
		{
			return base.Cast<T>().GetEnumerator();
		}
		public void Add(T item)
		{
			base.Add(item);
		}
		public bool Contains(T item)
		{
			return base.Contains(item);
		}
		public void CopyTo(T[] array, int arrayIndex)
		{
			base.CopyTo(array, arrayIndex);
		}
		public bool Remove(T item)
		{
			return base.Remove(item);
		}
		public int IndexOf(T item)
		{
			return base.IndexOf(item);
		}
		public void Insert(int index, T item)
		{
			base.Insert(index, item);
		}
		public new T this[int index]
		{
			get { return (T)base[index]; }
			set { base[index] = value; }
		}
	}
	
