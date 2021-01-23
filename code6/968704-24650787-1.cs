    private DebounceTimer _timer;
    void Init()
    {
        // myMethod will be called 4000ms after the
        // last call to _timer.Reset()
        _timer = new DebounceTimer(myMethod, 4000);
    }
    void testcase()
    {
        _timer.Reset();
    }
    void myMethod()
    {
        //some work
    }
    public void Dispose()
    {
        // don't forget to cleanup when you're finished testing
        _timer.Dispose();
    }
