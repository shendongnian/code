	public async Task DoQueryStuffAsync()
	{
		while (someCondition)
		{
			var results = await LimitedQueryAsync(url);
			
			// do stuff with results
			await Task.Delay(1000);
		}
	}
	
