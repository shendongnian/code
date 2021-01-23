    public void SomeOtherFunction()
    {
        OnTriggerBehaviour someObject;
        if(currentLevel == 1)
            someObject = new class1() as OnTriggerBehaviour;
        else
            someObject = new class2() as OnTriggerBehaviour;
    
        // Call the method via the interface
        someObject.OnTriggerEnter2d();
    }
