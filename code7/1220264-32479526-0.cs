    private void func()
    {
        var obj = (IMyInterface)GetAnyObject();
        callFunc(obj);
    }
    private void callFunc(IMyInterface o)
    {
        ...
    }
