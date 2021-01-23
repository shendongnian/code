	public class People : INotifyPropertyChanged
	{
		private string personName;
		public event PropertyChangedEventHandler PropertyChanged;
		
         protected void OnPropertyChanged([CallerMemberName] string propertyName = null) 
           { 
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
           }
		public string PersonName
		{
			get
			{
				return this.personName;
			}
			set
			{
				if( this.personName != value)
				{
					this.PersonName = value;
					this.NotifyPropertyChanged();
				}
			}
		}
		
		public int Age { get; set; }
		public double Income { get; set; }
	}
