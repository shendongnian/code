	public class Ethernet : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
	
		private string timeStamp;
	
		public string TimeStamp
		{
			get { return timeStamp; }
			set { this.NotifySetProperty(ref timeStamp, value, () => this.TimeStamp); }
		}
	}
