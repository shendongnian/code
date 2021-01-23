        class ListenToMe
        {
    	    public event EventHandler OnPropertyChanged;
    
    		private string _name;
        	public string Name
    	    {
    		    get{return _name;}
    	    	set
    		    {
    			    if (_name!=value)
        			{
        				this._name = value;
    	    			OnPropertyChanged(this,new EventArgs());
    		    	}
        		}
        	}
        }
    
        public static void Main()
        {
        	ListenToMe someone = new ListenToMe();
        	someone.OnPropertyChanged += (o,e) => Console.WriteLine("My new name is: "+ someone.Name); // we will do something whenever props change
        	someone.Name = "Mary"; // upon changing it, it appears on Console
        	someone.Name = "Lucy";
        	someone.Name = "Angelica";
        }
