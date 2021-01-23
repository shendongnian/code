    public class MyClass
    {
    	private bool _buttonEnabled;
    	public bool ButtonEnabled
    	{
    	    get
    	    {
    	    	return _buttonEnabled;
    	    }
    	    set
    	    {
    	    	_buttonEnabled = value;
                OnPropertyChanged();
    	    }
    	}
    
    	public SetButtonEnabled()
    	{
    		ButtonEnabled = checkboxes_enabled;
    	}
    
    	public event PropertyChangedEventHandler PropertyChanged;
    	private void OnPropertyChanged<T>([CallerMemberName]string caller = null) 
    	{
    		var handler = PropertyChanged;
    		if (handler != null) 
    		{
    			handler(this, new PropertyChangedEventArgs(caller));
    		}
    	}
    }
