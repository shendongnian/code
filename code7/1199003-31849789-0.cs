	public void Accumulate(SqlDateTime recordDateTime, SqlInt32 value)
	{
		if (latestDateTime.IsNull)
		{
			latestDateTime = recordDateTime;
			latestValue = value;
		}
		else
		{
			if (!recordDateTime.IsNull)
			{
				if (recordDateTime > latestDateTime)
				{
					latestDateTime = recordDateTime;
					latestValue = value;
				}
			}
		}
	}
