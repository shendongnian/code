	public class ViewModelBase : INotifyPropertyChanged, IRequestClose
	{
		protected event PropertyChangedEventHandler _propertyChanged;
		protected bool propertyAdded { get; private set; }
		public event PropertyChangedEventHandler PropertyChanged
		{
			add
			{
				_propertyChanged += value;
				propertyAdded = true;
			}
			remove { _propertyChanged -= value; }
		}
	
		protected void OnPropertyChanged(string propertyName)
		{
			PropertyChangedEventHandler handler = _propertyChanged;
	
			if (handler != null)
			{
				handler(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		public Delegate[] Get_PropertyChanged()
		{
			isPropertyAdded = false;
			Delegate[] delegates = new Delegate[0];
			if (_propertyChanged != null)
			{
				delegates = _propertyChanged.GetInvocationList();
				_propertyChanged = null;
			}
			
			return delegates;
		}
	}
