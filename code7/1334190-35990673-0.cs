	public event EventHandler SomeEvent;
	private void OnSomeEvent() {
		var someEvent = SomeEvent;
		if (someEvent != null) {
			someEvent(this, EventArgs.Empty);
		}
	}
