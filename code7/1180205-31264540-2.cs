	static public double LinearInterpolation(double newOaDate, double firstOaDate, double lastOaDate, double firstValue, double lastValue)
	{
		if ((lastOaDate - firstOaDate) == 0)
		{
			return (firstValue + lastValue) / 2;
		}
		else
		{
			return firstValue + (newOaDate - firstOaDate) * (lastValue - firstValue) / (lastOaDate - firstOaDate);
		}
	}
