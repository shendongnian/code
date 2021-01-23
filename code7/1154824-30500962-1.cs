    public void Log(MyValues type = MyValues.File)
    {
    	switch (type)
    	{
    		case MyValues.File:
    			//Do file stuff here
    			break;
    		case MyValues.Database:
    			//Do database stuff here
    			break;
    		default:
    			throw new ArgumentException("You passed in a dodgy value!");
    	}
    }
