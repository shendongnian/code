    public class ViewModelBase : INotifyPropertyChanged
    {
    	public event PropertyChangedEventHandler PropertyChanged;
		protected bool SetProperty<T>(ref T storage, T value,
										[CallerMemberName] string propertyName = null)
		{
			if (Object.Equals(storage, value))
				return false;
			storage = value;
			OnPropertyChanged(propertyName);
			return true;
		}
		protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
		internal bool ProcPropertyChanged<T>(ref T currentValue, T newValue, [CallerMemberName] string propertName = "")
		{
			return SetProperty(ref currentValue, newValue, propertName);
		}
		internal void ProcPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
