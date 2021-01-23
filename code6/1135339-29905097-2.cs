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
				string result = null;
				// run processing on another thread
				await Task.Run(() =>
				{
					// emulate hard-work
					Thread.Sleep(5000);
					result = "Here are the results: bla bla bla";
				});
				
				// update the property on the view model, which will lead to updating a textblock bound to this property				
				// thanks to the "await" keyword, this line of code will be executed only when the task finishes
				PathInfo = result;
			}
			finally
			{
				ProcessPathsCommand.IsEnabled = true;
			}
		}
