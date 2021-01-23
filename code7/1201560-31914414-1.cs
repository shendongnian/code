    public List<Label> foo1(ref ISomeInterface[] all)
    {
        all = new ISomeInterface[0]; //you will get empty array outside method
    }
    
    public List<Label> foo1(ISomeInterface[] all)
    {
        all = new ISomeInterface[0]; //you will get empty array only inside method
    }
