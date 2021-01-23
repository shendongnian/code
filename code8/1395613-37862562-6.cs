	public class MyCustomComparer : IComparer<int>
	{
		private readonly int _cutOffPointInclusive;
		
		public MyCustomComparer(int cutOffPointInclusive)
		{
			_cutOffPointInclusive = cutOffPointInclusive;
		}
		
		public int Compare(int x, int y)
		{
			if (x <= _cutOffPointInclusive || y <= _cutOffPointInclusive)
			{
				return x.CompareTo(y);
			}
			else 
			{				
				return y.CompareTo(x);
			}
		}
	}
