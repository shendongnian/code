    class TestState
    {
        public string Name { get; set; }
    }
    //initialization of some private field
    ConditionalWeakTable<IWebDriver, TestState> myTestsByDriver = new ConditionalWeakTable<IWebDriver, TestState>();
    ...
    
    //usage:
    myTestsByDriver.GetOrCreateValue().Name = "My_First_Test";
    //etc.
