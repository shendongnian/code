    public class ConcurrentCircularFixedList<T>
	{
		private readonly int _size;
		private int _offset;
		private readonly object _locker = new Object();
		private readonly T[] _list;
		public ConcurrentCircularFixedList(int size)
		{
			_size = size;
			_offset = 0;
			_list = new T[_size];
		}
		public int Enqueue(T item)
		{
			lock (_locker)
			{
				_list[_offset] = item;
				Debug.Write("B " + _offset);
				_offset += 1;
				if (_offset == _size)
					_offset = 0;
				Debug.Write("A " + _offset + "\n");
				return _offset;
			}
		}
		public T[] Dump()
		{
			lock (_locker)
				return _list.ToArray();
		}
	}
