	public virtual void Publish(T value)
	{
		foreach (var sub in _subscribers.Distinct().ToArray())
		{
			try
			{
				sub.OnNext(value);
			}
			catch { }
		}
	}
