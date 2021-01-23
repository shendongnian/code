	public class NonZeroArray<T>
	{
		private readonly Array array;
		
		public T this[int i]
		{
			get { return (T)array.GetValue(i); }
			set { array.SetValue(value, i); }
		}
		
		public NonZeroArray(int length, int lowerBounds = 0)
		{
			array = Array.CreateInstance(typeof(T), new int[] { length}, new int[] { lowerBounds } );
		}
	}
