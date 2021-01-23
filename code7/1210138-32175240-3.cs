    public void CommonOperations(/*Some parameteres as needed.*/)
    {
        // Shared operations between two methods.
    }
    public void WorkAt()
    {
        string location = "home";
        CommonOperations(/*Some parameteres as needed.*/);
        //do something
    }
    
    public void WorkAt(string location)
    {
        CommonOperations(/*Some parameteres as needed.*/);
        //do the other thing
    }
