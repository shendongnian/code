    public class ContentItem : INotifyPropertyChanged
    {
    	private string contentText;
    	private string header;
    
    	public ContentItem(string header, string contentText)
    	{
    		Header = header;
    		ContentText = contentText;
    	}
    
    	public string Header
    	{
    		get { return header; }
    		set
    		{
    			header = value;
    			OnPropertyChanged();
    		}
    	}
    
    	public string ContentText
    	{
    		get { return contentText; }
    		set
    		{
    			contentText = value;
    			OnPropertyChanged();
    		}
    	}
    
    	public event PropertyChangedEventHandler PropertyChanged;
    
    	protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    	{
    		PropertyChangedEventHandler handler = PropertyChanged;
    		if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
    	}
    }
