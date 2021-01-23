	public class People : INotifyPropertyChanged
	{
		private string personName;
		public event PropertyChangedEventHandler PropertyChanged;
		public void NotifyPropertyChanged(string propName)
		{
			if (this.PropertyChanged != null)
			this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
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
					this.NotifyPropertyChanged(nameof(PersonName));
				}
			}
		}
		
		public int Age { get; set; }
		public double Income { get; set; }
	}
