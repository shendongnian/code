	public class MainWindowViewModel : ViewModelBase
	{
		public MainWindowViewModel()
		{
		}
		public NotifyTaskCompletion<List<File>> googleDriveFolders { get; private set; }
		private ObservableCollection<File> _googleDriveFolders;
		public ObservableCollection<File> googleDriveFolder
		{
			get { return _googleDriveFolders; }
			set
			{
				_googleDriveFolders = value;
				RaisePropertyChanged();
			}
		}
		public async void OnNavigatedTo(NavigationContext context) 
		{
			var service = DriveHelper.createDriveService("client_secret.json", false)
			// ERROR
			googleDriveFolder = await DriveHelper.getFiles(service), "trashed=false and mimeType = 'application/vnd.google-apps.folder'");
		}
	...
	}
