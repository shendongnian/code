    // Default constructor (This constructor is provided automatically by
    // default if not explicitly defined. Including it in the class definition
    // allows you to initialize the object with default parameters when creating
    // a new Data object without providing any parameters.)
    public Data()
    {
    }
    
    // Overloaded constructor that accepts a single parameter
    public Data(Title_Input input)
    {
        //Do something with the parameter input
        ...
    }
    
    // Overloaded constructor that accepts 6 arguments
    public Data(int priority, string title, string description, DateTime calender, string description_2, int tick)
    {
    	// Menu (form)
    	Title = title;
    	Description = description;
    
    	// Create new task (form)
    	Calender = calender;
    	Description_2 = description_2;
    	Tick = tick;
    	Priority = priority;
    	...
     }
