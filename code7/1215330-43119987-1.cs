	...
	async void OnDoSomethingLong(...)
	{
		if (!this.IsBusy)
		{
			try
			{
				this.IsBusy = true;
				
				//await long operation here, i.e.:
				await Task.Run(() => {/*your long code*/});
			}
			finally
			{
				this.IsBusy = false;
			}
		}
	}
	...
