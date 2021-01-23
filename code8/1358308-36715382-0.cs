    public class ScanMessage
    {
        public delegate void OnScanMessageReceived(string message);
        private static ScanMessage _scanMessage = new ScanMessage();
        private ScanMessage()
        {
        }
        public static ScanMessage Instance
        {
            get
            {
                return _scanMessage;
            }
        }
        public void BroadCastMessage(string message)
        {
            MessageReceived(message);
        }
        public event OnScanMessageReceived MessageReceived;
    }
