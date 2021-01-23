	class MainViewModel : ViewModelBase
	{
		private PropertyChangedNotifier<MainViewModel> _notifier;
		public new event PropertyChangedEventHandler PropertyChanged
		{
			add { _notifier.PropertyChanged += value; }
			remove { _notifier.PropertyChanged -= value; }
		}
	
		public MainViewModel()
		{
			_notifier = new PropertyChangedNotifier<MainViewModel>(this);
		}
	
		protected new void OnPropertyChanged(string propertyName)
		{
			if (isPropertyAdded)
			{
				foreach (Delegate d in Get_PropertyChanged())
				{
					_notifier.PropertyChanged += (PropertyChangedEventHandler)d;
				}
			}
			
			_notifier.OnPropertyChanged(propertyName);
		}
	}
