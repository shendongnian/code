    public class SubSystem:INotifyPropertyChanged
     {
    	public event PropertyChangedEventHandler PropertyChanged;
    
    	[XmlAttribute("Name")]
    	[DataMember]
    	public string Name
    	{
    		get { return _name; }
    		set { 
    			_name = value;
    			OnPropertyChanged("Name");
    			}
    	}
    
    	[DataMember]
    	public int DeviceCount
    	{
    		get { return _deviceCount; }
    		set { 
    			_deviceCount = value; 
    			OnPropertyChanged("DeviceCount");
    			} 
    	} 
    
    
    
    	protected void OnPropertyChanged(string name)
    	{
    	PropertyChangedEventHandler handler = PropertyChanged;
    	if (PropertyChanged != null)
    		PropertyChanged(this, new PropertyChangedEventArgs(name));
    	}
    }
