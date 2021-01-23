    Dictionary<string, string> myDictionary = new Dictionary<string, string>()
            {
                {"cat", "miaow"},
                {"dog", "woof"},
                {"iguana", "grekkkk?"}
    
            };
    public void Main()
    {
    
    	// create a dictionary and add values
    	
    
    	// get a value from the dictionary and display it
    	MessageBox.Show(myDictionary["cat"]);
    
    	// call another procedure
    	up();
    
    	// call another procedure that calls another procedure
    	sh();
    
    }
    
    public void up() 
    {
    
    	// get a value from the dictionary and display it
    	MessageBox.Show(myDictionary["dog"]);
    
    }
    
    public void sh()
    {
    
    	// call another procedure
    	up();
    
    }
