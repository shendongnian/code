    public class MyReceiveFilter: IReceiveFilter<MyRequestInfo>
    {
    // This Method (Filter) is called whenever there is a new request from a connection/session 
    //- This sample method will convert the incomming Byte Array to Unicode string
        public MyRequestInfo Filter(byte[] readBuffer, int offset, int length, bool toBeCopied, out int rest)
        {
            rest = 0;
            try
            {
                var dataUnicode = Encoding.Unicode.GetString(readBuffer, offset, length);
                var deviceRequest = new MyRequestInfo { Unicode = dataUnicode };
                return deviceRequest;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public void Reset()
        {
            throw new NotImplementedException();
        }
        public int LeftBufferSize { get; }
        public IReceiveFilter<MyRequestInfo> NextReceiveFilter { get; }
        public FilterState State { get; }
    }
