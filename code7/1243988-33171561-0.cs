    public class runtimeObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
    
        protected void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
    
        }
        
    	private readonly ObservableCollection<string> _hashList = new ObservableCollection<string>();
    	public ObservableCollection<string> hashList
    	{
    		get { return _hashList; }
    	}
    }
