    public void LoadFile(string path)
    {
        this.GetOcx().GetType().InvokeMember("LoadFile", BindingFlags.InvokeMethod | 
          BindingFlags.OptionalParamBinding, null, this.GetOcx(), new object[1] { path });
    }
