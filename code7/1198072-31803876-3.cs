    public void SomeOtherFunction()
    {
        // In your code, the object will be provided elsewhere, in which case
        // you may want to use the 'as' operator to convert the object
        // reference to the interface and test for 'null' before using it.
        // This example shows that an interface can be used to hold a reference
        // to different types of object, providing they both implement the
        // same interface.
        ITriggerBehaviour someObject;
        if(currentLevel == 1)
            someObject = new class1();
        else
            someObject = new class2();
    
        // Call the method via the interface
        someObject.OnTriggerEnter2d();
    }
