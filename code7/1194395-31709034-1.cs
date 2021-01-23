    public class Model : INotifyPropertyChanged
    {
    	// From the INotifyPropertyChanged interface
     	public event PropertyChangedEventHandler PropertyChanged;
    
        private string foo;
    	public String Foo
    	{
    		get { return this.foo; }
    		set
    		{
    		    this.foo = value;
    		    // Old code:
    		    PropertyChanged(this, new PropertyChangedEventArgs("Foo"));
    
    		    // New Code:
    			PropertyChanged(this, new PropertyChangedEventArgs(nameof(Foo)));		    
    		}
    	}
    }
