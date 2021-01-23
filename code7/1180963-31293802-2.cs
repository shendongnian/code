	public class CustomerOverviewViewModel : INotifyPropertyChanged 
	{
		readonly Task<string> _dataTask;
		readonly Task _notifierTask;
		public event PropertyChangedEventHandler PropertyChanged = delegate {};
		public string Data
		{
			get
			{
				return _dataTask.IsCompleted ? 
					_dataTask.GetAwaiter().GetResult() : 
					"loading...";
			}
		}
		public CustomerOverviewViewModel()
		{
			_dataTask = LoadFullCustomerListAsync();
			Func<Task> notifier = async () =>
			{
				try 
				{	        
					await _dataTask;
				}
				finally
				{
					this.PropertyChanged(this, new PropertyChangedEventArgs("Data"));
				}
			};
			// any exception thrown by _dataTask stays dormant in _notifierTask
			// and may go unobserved until GC'ed, but it will be re-thrown 
			// to the whenever CustomerOverviewViewModel.Data is accessed
			// from PropertyChanged event handlers
			_notifierTask = notifier(); 
		}
		async Task<string> LoadFullCustomerListAsync()
		{
			await Task.Delay(1000);
			return "42";
		}
	}
