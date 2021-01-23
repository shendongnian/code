    /// <summary>
	/// Receives new status via the StatusMessage class received by the messenger.
	/// </summary>
	/// <param name="status"></param>
	private void Messenger_ReceiveMessage(StatusMessage status)
	{
		StatBarTextProp = status.NewStatus;
	}
