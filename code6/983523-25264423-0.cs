    public delegate void CallbackMsg(IntPtr bstrMsg, int unused1, int unused2, int unused3);
    
    [ComVisible(true)]
    public void TestProcess(int callback)
    {
       IntPtr ptrBSTR = Marshal.StringToBSTR("Hello Office");
       CallbackMsg x = (CallbackMsg)Marshal.GetDelegateForFunctionPointer(new IntPtr(callback), typeof(CallbackMsg));
       x.Invoke(ptrBSTR, 2, 4, 6);
       Marshal.FreeBSTR(ptrBSTR); //MUST free it
    }
