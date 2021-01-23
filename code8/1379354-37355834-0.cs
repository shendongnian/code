    [Serializable][DataContract]
    public class MessageDialog : INotifyPropertyChanged
    {
    	#region public string Body
    	private string m_Body;
    	public string Body
    	{
    		get { return m_Body; }
    		private set
    		{
    			if (m_Body == value)
    				return;
    		
    			m_Body = value;
    			this.NotifyPropertyChanged();
    		}
    	}
    	#endregion
    
    	#region INotifyPropertyChanged Members
    	public event PropertyChangedEventHandler PropertyChanged;
    	private void NotifyPropertyChanged([CallerMemberName]string propertyName = "")
    	{
    		if (PropertyChanged != null)
    		{
    			PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
    		}
    	}
    	#endregion
    }
