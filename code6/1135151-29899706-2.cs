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
					// in WPF you can update the bound property right from another thread and WPF will automatically dispatch PropertyChanged event to the main UI thread. In WinForms this would lead to an exception.
					PathInfo = "Here are the results: bla bla bla";
				});
				// In WinForms you would need to update the bound property here:
				// Thanks to Tasks and await this line of code will be executed only after the task is finished
				// PathInfo = resultFromTaskThread;
			}
			finally
			{
				ProcessPathsCommand.IsEnabled = true;
			}
		}
