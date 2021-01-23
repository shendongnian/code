    public class MyClass : INotifyPropertyChanged
    {
    	public int TheInt { get; set; }
    	public string TheString { get; set; }
    
    	TheEnum theEnum;
    
    	public event PropertyChangedEventHandler PropertyChanged;
    
    	private void NotifyPropertyChanged(string propertyName)
    	{
    		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    	}
    
    	public TheEnum TheEnum
    	{
    		get
    		{
    			return theEnum;
    		}
    
    		set
    		{
    			theEnum = value;
    			NotifyPropertyChanged("TheEnum");
    		}
    	}
    }
