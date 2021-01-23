    public abstract class ViewModelBase : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
		internal void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
		protected ViewModelPropertyChange SetPropertyValue<T>(ref T property, T value, [CallerMemberName] string propertyName = null)
		{
			property = value;
			OnPropertyChanged(propertyName);
			return new ViewModelPropertyChange(this);
		}
	}
