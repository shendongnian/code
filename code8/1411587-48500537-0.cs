    public const long TicksPerMillisecond = 10000;
	public const long TicksPerSecond = TicksPerMillisecond * 1000;
	public static bool IsEqualIgnoreMilliseconds(this DateTime date, DateTime compareDate)
	{
		long tickDiff = date.Ticks - compareDate.Ticks;
		return tickDiff > 0 ? tickDiff < TicksPerSecond : tickDiff < -TicksPerSecond;
	}
