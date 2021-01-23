    InstanceOfYourClass.PropertyChanged += SomeFunctionThatHandlesIt;
    
    private void SomeFunctionThatHandlesIt(object sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == "SomeProperty")
        {
            DoSomething();
        }
    }
