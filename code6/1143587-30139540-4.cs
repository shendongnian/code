    private string GetMessageType()
    {
        //Your method
    }
    public Test(string value, string messageType)
    {
        this.testValue = value;
        this.mType = messageType;
    }
    //Call `GetMessageType` in the constructor for `messageType` parameter
    public Test (string value) : this (value, GetMessageType())
    {
        
    }
