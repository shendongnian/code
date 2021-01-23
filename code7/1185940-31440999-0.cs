	class HasOutput
	{
		public string Output()
	    {
			return Date + " " + Time;
		}
	}
	class Hour : HasOutput, IMoment
	{
		public string Date;
		public string Time;
		public Hour (string s)
		{
			string[] parts = s.Split(';');
			this.Date = parts[0];
			this.Time = parts[1];
		}
	}
	class Day : HasOutput, IMoment
	{
		public string Date;
		private string Time;
		public Day(Hour hour)
		{
			this.Date = hour.Date;
			this.Time = hour.Time;
		}
	}
