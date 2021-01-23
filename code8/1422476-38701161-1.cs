	public class MyViewModel : ViewModelBase
	{
		private bool _isDirty;
		private bool _enabled;
		
		public MyViewModel()
		{
		    SaveCommand = new RelayCommand(Save, CanSave);
		}
	   
		public ICommand SaveCommand { get; }
		private void Save() 
		{
		   //TODO: Add your saving logic
		}
		private bool CanSave()
		{
			return IsDirty;
		}
		public bool IsDirty
		{  
		   get { return _isDirty; }
		   private set 
		   {
			   if (_isDirty != value) 
			   {
				   RaisePropertyChanged(); 
			   }
		   }
		}
		public bool Enabled 
		{
			get { return _enabled; }
			set
			{
			   if (_enabled != value)
			   {
				   _enabled = value;
				   IsDirty = true;
			   }
			   //Whatever code you need to raise the INotifyPropertyChanged.PropertyChanged event
			   RaisePropertyChanged();
			}
		}
    }
