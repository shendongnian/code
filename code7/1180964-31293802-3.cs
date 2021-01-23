    [TestMethod]
	public async Task Test()
	{
		var customerOverviewViewModel = new CustomerOverviewViewModel();
		var tcs = new TaskCompletionSource<bool>();
		PropertyChangedEventHandler handler = (s, e) =>
		{
			if (e.PropertyName == "Data")
				tcs.TrySetResult(true);
		};
		customerOverviewViewModel.PropertyChanged += handler;
		try 
		{
			await tcs.Task;
		}
		finally
		{
			customerOverviewViewModel.PropertyChanged -= handler;
		}
	    Assert.IsTrue(customerOverviewViewModel.Data == "42");
	}
