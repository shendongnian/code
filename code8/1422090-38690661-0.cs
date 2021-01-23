    class MyClass
    {
    ISomeInterface _interfaceObj;
    public MyClass(ISomeInterface interfaceObj)
    {
        _interfaceObj = interfaceObj;
    }
    public bool ShouldSendLogic()
    {
        var status = _interfaceObj.IsSuccess();
        if (status)
        {
            SendInvoice();
            // do some operation
        }
        return status;
    }
    }
