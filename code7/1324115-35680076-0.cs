	private static void InvokeEvents<T>(string receivedMessage, string receivedTopic, T eventDelegate)
	{
		if (eventDelegate != null)
		{
			var customEventArgs = new CustomEventArgs(receivedMessage, receivedTopic);
			((Delegate)(object)eventDelegate).DynamicInvoke(customEventArgs);
		}
	}
