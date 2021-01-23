    public class EWrapperImpl : EWrapper
    {
        public EWrapperImpl()
        {
            ClientSocket = new EClientSocket(this);
        }
    
        public EClientSocket ClientSocket { get; set; }
    }
