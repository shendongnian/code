    class Model : INotifyPropertyChanged
    {
    	private int _Name = default(int);
    	public int Name
    	{
    		get { return _Name; }
    		set
    		{
    			SetValue(ref this._Name, value);
    		}
    	}
    
   		private void SetValue<T>(ref T property, T value, [CallerMemberName]string propertyName = null)
   		{
   			if (object.Equals(property, value) == false)
 			{
   				property = value;
   
    			if (this.PropertyChanged != null)
    			{
    			    this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
    			}
    		}
		}
    
    	public event PropertyChangedEventHandler PropertyChanged;
   	}
