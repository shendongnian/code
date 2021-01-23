    public class Person: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
    	private string _name;
        public string Name { 
    			get{
    				return _name;
    			}
    				set
                {
    				_name = value;
    				OnPropertyChanged("Name");
                    }
                }
     }
    	private string _FirstName;
        public string FirstName { 
    		get
    		{
    			return _FirstName;
    		} 
    		set
    		{
    			_FirstName = value;
    			OnPropertyChanged("FirstName");
    		} 
    	}
    
    	 protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
