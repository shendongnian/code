   		public class DocumentType : INotifyPropertyChanged
		{
			public event PropertyChangedEventHandler PropertyChanged;
			private void OnPropertyChanged(string nameOfProperty)
			{
				if (PropertyChanged != null)
					PropertyChanged(this, new PropertyChangedEventArgs(nameOfProperty));
			}
			private string _Name;
			public string Name { get { return _Name; } set { _Name = value; OnPropertyChanged("Name"); } } 
            ...
		}
	}
