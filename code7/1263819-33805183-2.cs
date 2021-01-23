    public abstract class WiresharkFile:BaseObservableObject
    {
        private string _fileName;
        private int _packets;
        private int _packetsSent;
        private string _duration;
        public int Packets
        {
            get { return _packets; }
            set
            {
                _packets = value;
                OnPropertyChanged();
            }
        }
        public int PacketsSent
        {
            get { return _packetsSent; }
            set
            {
                _packetsSent = value;
                OnPropertyChanged();
            }
        }
    }
