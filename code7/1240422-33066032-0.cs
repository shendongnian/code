    public struct FBarWidth : INotifyPropertyChanged
    {
        private int _Stopped;
        public int Stopped
        {
            get { return _Stopped; }
            set
            {
                _Stopped = value;
                OnPropertyChanged("_Stopped");
            }
        }
    
        private int _Running;
        //And more variables
    	
    	private void OnPropertyChanged(string propertyName)
    	{
    		PropertyChangedEventHandler handler = PropertyChanged;
    		if (handler != null)
    		{
    			handler(this, new PropertyChangedEventArgs(propertyName));
    		}
    	}
    	public event PropertyChangedEventHandler PropertyChanged;
    }
