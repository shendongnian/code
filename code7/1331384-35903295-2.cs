    public class SomeObject : INotifyPropertyChanged
    {
    	private SynchronizationContext syncContext;
    
    	public SomeObject()
    	{
    		syncContext = SynchronizationContext.Current;
    	}
    
    	private decimal alertLevel;
    
    	public decimal AlertLevel
    	{
    		get { return alertLevel; }
    		set
    		{
    			if (alertLevel == value) return;
    			alertLevel = value;
    			OnPropertyChanged("AlertLevel");
    		}
    	}
    
    	public event PropertyChangedEventHandler PropertyChanged;
    
    	private void OnPropertyChanged(string propertyName)
    	{
    		var handler = PropertyChanged;
    		if (handler != null)
    		{
    			if (syncContext != null)
    				syncContext.Post(_ => handler(this, new PropertyChangedEventArgs(propertyName)), null);
    			else
    				handler(this, new PropertyChangedEventArgs(propertyName));
    		}
    	}
    }
