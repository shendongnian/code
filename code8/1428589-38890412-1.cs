    [Test]
    public void CallWithText_WhenCalled_CallsCallable()
    {
        var caller = new Caller();
        var callable = Substitute.For<ICallable>();
    
        caller.CallWithText(callable);
    
        callable.Received(1).ShowText(Properties.Resources.TextWithNewLine);
    }
