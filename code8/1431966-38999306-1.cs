	public static T PollUntilReady<T>(Func<T> functionThatMight503)
	{
		return PollUntilReady(functionThatMight503, null);
	}
	public static T PollUntilReady<T>(
		Func<T> functionThatMight503,
		PollingOptions pollingOptions)
	{
		throw new NotSupportedException(); //Whatever
	}
