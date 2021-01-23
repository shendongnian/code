    class Host: NetComm.Host
    {
        public Host(int port):base(port)
        {
            StartConnection();
            DataReceived += Host_DataReceived;
        }
        void Host_DataReceived(string ID, byte[] Data)
        {
            Brodcast(Data);
        }
    }
