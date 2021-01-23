     private string _testString;
    public string TestString
    {
        get { return _testString; }
        set
        {
            // Custom Method, returns true if property has changed
            if (SetProperty(ref _testString, value))
            {
                DoSomeStuff();
            }
        }
    }
    private async void DoSomeStuff()
    {
        // Do long lasting calls here
        await Task.Delay(3000);
    }
