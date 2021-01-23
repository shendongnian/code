	class CheckedList : List<int>
	{
		public void Add(long x)
		{
			if (int.MaxValue < x || int.MinValue > x) throw new ArgumentOutOfRangeException("Invalid");
			var i = (int) x;
			base.Add(i);
		}
	}
