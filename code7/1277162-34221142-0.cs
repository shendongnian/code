        public class MyClass: INotifyPropertyChanged
        {   
    	private string myField ;
    	public string MyField 
    	{
    		get { return MyField ; }
    		set 
    		{ 
    			MyField = value;
    			Raise("MyField ");
    		}
    	}
    
    	public event PropertyChangedEventHandler PropertyChanged;
    
    	public void Raise(string propertyName)
    	{
    		if (PropertyChanged != null)
    		{
    			PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
    		}
    	}
        }
