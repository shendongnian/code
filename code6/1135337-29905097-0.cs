	public class ViewModel : INotifyPropertyChanged
	{
		...
		
		public string PathInfo { ... } // raises INotifyPropertyChanged.PropertyChanged event from the setter
		public RelayCommand ProcessPathsCommand { get; set; }
		public ViewModel()
		{
			ProcessPathsCommand = new RelayCommand(ProcessPaths);
		}
		public async void ProcessPaths()
		{
			// disable the command, which will lead to disabling a button bound to the command
			ProcessPathsCommand.IsEnabled = false;
			try
			{
				// run processing on another thread
				await Task.Run(() =>
				{
					// emulate hard-work
					Thread.Sleep(5000);
					// update the property on the view model, which will lead to updating a textblock bound to this property				
					PathInfo = "Here are the results: bla bla bla";
				});
			}
			finally
			{
				ProcessPathsCommand.IsEnabled = true;
			}
		}
