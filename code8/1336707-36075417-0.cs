    public class DataViewModel : INotifyPropertyChanged
    {
    	private string _theString;
    
    	public DataViewModel()
    	{
    		Strings = new ObservableCollection<string>();
    	}
    
    	public event PropertyChangedEventHandler PropertyChanged;
    
    	public ObservableCollection<string> Strings { get; set; }
    	
    	public string TheString
    	{
    		get
    		{
    			return _theString;
    		}
    		set
    		{
    			_theString = value;
    			NotifyPropertyChanged(nameof(TheString));
    		}
    	}
    
    	private void NotifyPropertyChanged(String info)
    	{
    		if (PropertyChanged != null)
    		{
    			PropertyChanged(this, new PropertyChangedEventArgs(info));
    		}
    	}
    }
