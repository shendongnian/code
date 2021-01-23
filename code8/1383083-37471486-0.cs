	public class core : INotifyPropertyChanged
	{
		static public ObservableCollection<core> cores { get; set; }
            = new ObservableCollection<core>();
		string namef = "building";
		public core()
		{
			cores.Add(this);
		}
		public string Namef
		{
			get { return namef; }
			set 
			{ 
				if(namef == value) return;
			
				namef = value; 
				OnPropertyChanged("Namef");
			}
		}
			
		public event PropertyChangedEventHandler PropertyChanged;
		protected virtual void OnPropertyChanged(String propertyName)
		{
			if (PropertyChanged == null) return;
			PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}
