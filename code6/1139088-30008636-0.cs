    class SomeData 
    {
        private readonly byte _firstByte;
        private readonly byte _secondByte;
        private readonly string _stringData;
        public byte FirstByte { get { return _firstByte; }  }
        public byte SecondByte { get { return _secondByte; }  }
        public string StringData { get { return _stringData; } }
        public SomeData(byte first, byte second, string data) 
        {
            _firstByte = first;
            _secondByte = second;
            _stringData = data;
        }
    }
