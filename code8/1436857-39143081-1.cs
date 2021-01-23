    public class Message:ViewModelBase
    {
    	private string _shortTextMessage;      
    	public string ShortTextMessage 
    	{
    		get { return _shortTextMessage; }
    		set
    		{
    			_shortTextMessage= value;
    			OnPropertyChanged();
    		}
    	}
      	private string _statusColor;      
    	public string StatusColor 
    	{
    		get { return _statusColor; }
    		set
    		{
    			_statusColor= value;
    			OnPropertyChanged();
    		}
    	}
    }
