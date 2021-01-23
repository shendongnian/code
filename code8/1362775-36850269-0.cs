    public class TitleChangedEventArgs: EventArgs
    {
    	public string Title { get; private set; }
    
    	public TitleChangedEventArgs(string title)
    	{
    		Title = title;
    	}
    }
