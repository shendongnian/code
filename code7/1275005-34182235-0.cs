	public async Task<int> AddAsync(int num1, int num2)
	{
		var context = OperationContext.Current
		var sessionId = OperationContext.Current.SessionId;
		return await Task<int>.Run(() =>
		{
			if (context == null)
			{
				return -2;
			}
			else if (sessionId == null)
			{
				return -1;
			}
			return num1 + num2;
		});
	}
