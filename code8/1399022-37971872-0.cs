    public async void OnSomething(SomeEventArgs args)
    {
        SomeResult result = await _businessObject.AsyncCall();
        ApplySomethingOnTheGuiBasedOnTheResult(result);
    } 
