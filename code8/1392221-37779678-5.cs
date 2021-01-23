    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    delegate void HandlerCallbackDelegate(float value);
    
    [DllImport("CppDllTestProj.dll")]
    static extern void CallRightBack([MarshalAs(UnmanagedType.FunctionPtr)]HandlerCallbackDelegate callback);
    
    [DllImport("CppDllTestProj.dll")]
    static extern void CallMeBack([MarshalAs(UnmanagedType.FunctionPtr)]HandlerCallbackDelegate callback);
    HandlerCallbackDelegate callbackDel;
    
    // in the designer associated with button1
    private void button1_Click(object sender, EventArgs e)
    {
        if (this.callbackDel == null)
        {
            this.callbackDel = new HandlerCallbackDelegate(this.Callback);
        }
        CallRightBack(callbackDel);
    }
    
    // in the designer associated with button2
    private void button2_Click(object sender, EventArgs e)
    {
        if (this.callbackDel == null)
        {
            this.callbackDel = new HandlerCallbackDelegate(this.Callback);
        }
        CallMeBack(callbackDel);
    }
    
    void Callback(float value)
    {
        MessageBox.Show(value.ToString());
    }
