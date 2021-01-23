    delegate void FunctionNameCallBack(InputParams);
    private void FunctionName(InputParams)
    {
        if (this.InvokeRequired)
        {
            var d = new FunctionNameCallBack(FunctionName);
            this.Invoke(d, InputParams);
        }
        else
        {
            // Your Code here.
        }
    }
