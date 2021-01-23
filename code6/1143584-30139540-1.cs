    public Test(string value, string messageType)
    {
        If(messageType == null)
            //Do your manipulation if calling from one parameter constructor
        else
            //Do your normal manipulation
        this.testValue = value;
        this.mType = messageType;
    }
    'Constructor with one parameter
    public Test (string value) : this (value, null)
    {
        
    }
