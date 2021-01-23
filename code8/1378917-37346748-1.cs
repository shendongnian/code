	public sealed class CommandInputViewModel : INotifyPropertyChanged
	{
		private string _userText;
		public event PropertyChangedEventHandler PropertyChanged;
		public string UserText
		{
			get
			{
				return _userText;
			}
			set
			{
				_userText = value;
				OnPropertyChanged(nameof(UserText));
			}
		}
		private void OnPropertyChanged(string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
