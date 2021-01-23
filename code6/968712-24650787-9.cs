    void testcase()
    {
        _timer.Reset(() => myMethod());
    }
    void othertestcase()
    {
        // it's still a parameterless action, but it
        // calls another method with two parameters
        _timer.Reset(() => someOtherMethod(x, y));
    }
