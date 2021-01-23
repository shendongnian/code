    public class TcpClientMock : ITCPClient
    {
        private readonly List<string> _sentMessages;
        public TcpClientMock(List<string> sentMessages)
        {
            _sentMessages = sentMessages;
        }
        public void SendMessage(string Message)
        {
            _sentMessages.Add(Message);
        }
        
        //rest of non-implemented methods
    }
