    public class OwnObject : INotifyPropertyChanged
    {
    	private string _text;
    
    	public string Text
    	{
    		get { return _text; }
    		set { _text = value; NotifyPropertyChanged( "Text" ); IsIdChanged = true; }
    	}
        #region INotifyPropertyChanged Members
    	public event PropertyChangedEventHandler PropertyChanged;
    	#endregion
    	protected void NotifyPropertyChanged( String info )
    	{
    		if ( PropertyChanged != null )
    		{
    			PropertyChanged( this, new PropertyChangedEventArgs( info ) );
    		}
    	}
    }
