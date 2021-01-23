	public void Merge(Latest value)
	{
		if (latestDateTime.IsNull)
		{
			latestDateTime = value.latestDateTime;
			latestValue = value.latestValue;
		}
		else
		{
			if (!value.latestDateTime.IsNull)
			{
				if (value.latestDateTime > latestDateTime)
				{
					latestDateTime = value.latestDateTime;
					latestValue = value.latestValue;
				}
			}
		}
	}
