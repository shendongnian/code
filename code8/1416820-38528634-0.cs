    public class BufferReadyEventArgs : EventArgs
    {
        public BufferReadyEventArgs(string commonBuffer)
        {
            CommonBuffer = commonBuffer;
        }
        public string CommonBuffer {get; private set;}
    }
    
    Class Plugin()
    {
        public event EventHandler<BufferReadyEventArgs> OnBufferReady;
        public ClassPlugin(eGuiType _guyType)
        {
            GuiType = _guyType;
        }
        protected void Sp_DataReceived_Parent(object sender, SerialDataReceivedEventArgs e)
        {
            strCommonBuffer += serial.ReadExisting();
            if (strCommonBuffer.Contains("\r\n"))
            {
                RaiseOnBufferReady(strCommonBuffer);
                strCommonBuffer = string.Empty;
            }
        }
    
        protected virtual void RaiseOnBufferReady(string commonBuffer)
        {
            var temp = OnBufferReady;
            if(temp != null)
                temp(this, new BufferReadyEventArgs(commonBuffer));
        }
    }
    
    class ClassIO : ClassPlugin
    {
        public ClassIO(eGuiType _guyType) : base(_guyType)
        {
            ...
        }
    
        protected override void RaiseOnBufferReady(string commonBuffer)
        {
            base.RaiseOnBufferReady(commonBuffer);
    
            ...
        }
    }
