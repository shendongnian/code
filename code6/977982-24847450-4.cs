	public void Invoker<T>(Action<T> action, T p)
	{
		if (InvokeRequired)
			Invoke(action, p);
		else
			action(p);
	}
	private void SetLabel(string value)
	{
		label1.Text = value;
	}
