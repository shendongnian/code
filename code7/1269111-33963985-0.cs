	class ObjectInstance
	{
		public TimeSpan StartTime, EndTime;
		public TimeSpan PeakTime(TimeSpan peakTimeStart)
		{
			return Fit(peakTimeStart) - StartTime;
		}
		public TimeSpan OffPeakTime(TimeSpan peakTimeStart)
		{
			return EndTime - Fit(peakTimeStart);
		}
		private TimeSpan Fit(TimeSpan value)
		{
			return value < StartTime ? StartTime : value > EndTime ? EndTime : value;
		}
	}
