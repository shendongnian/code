	public class Progress<T>
	{
		public Progress(T value, int current, int total)
		{
			this.Value = value;
			this.Current = current;
			this.Total = total;
		}
		public T Value { get; private set; }
		public int Current { get; private set; }
		public int Total { get; private set; }
		public double Percentage
		{
			get
			{
				return (double)this.Current / (double)this.Total;
			}
		}
	}
