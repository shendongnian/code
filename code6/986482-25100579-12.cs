    public DateTime GetNextRunTime(ScheduleRequest request)
	{
		double diffMillis = (request.CurrentDate - request.BaseDate).TotalMilliseconds;
		double modMillis = (diffMillis % request.IntervalMillis);
		double timeLeft = (request.IntervalMillis - modMillis);
		ulong adjust = (request.Schedule == Schedule.Daily) ? (ulong)Schedule.Daily : 0;
		return request.CurrentDate.AddMilliseconds(timeLeft - adjust);
	}
