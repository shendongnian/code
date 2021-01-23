    class Program
    {
        private static YourDataParser _parser;
        static void Main(string[] args)
        {
            _parser = new YourDataParser();
            var serial = new SerialService("COM1");
            serial.DataReceived += serial_DataReceived;
        }
        static void serial_DataReceived(object sender, DataReceivedEventArgs e)
        {
            _parser.HandleTheData(e.Data, good =>
            {
                // here is your good data
                // This is not the main thread invoke your UI from here with the good data
                // Use BeginInvoke to invoke the main thread
            });
        }
    }
    public class YourDataParser
    {
        private List<byte> _buffer = new List<byte>(); 
        public void HandleTheData(byte[] rawdata, Action<string> goodData)
        {
            _buffer.AddRange(rawdata);
            foreach (var b in _buffer)
            {
                var thechar = (char) b;
                // handle your raw data... like look for the character '<'
                // or look for the end of line this would be CR (0x0D) LF (0x0A) 
                // you can reference the ASCII table for the characters byte values
            }
            // and return the good data 
            var data = "your good data after parsing it";
            goodData(data);
        }
    }
    public class DataReceivedEventArgs : EventArgs
    {
        public DataReceivedEventArgs(byte[] data)
        {
            Data = data;
        }
        public byte[] Data { get; private set; }
    }
    class SerialService
    {
        public event EventHandler<DataReceivedEventArgs> DataReceived;
        private SerialPort _port;
        public SerialService(string comm)
        {
            _port = new SerialPort(comm)
            {
                // YOUR OTHER SETTINGS HERE...
                ReceivedBytesThreshold = 1 // I think is better to increase this number if you know the minimum number of bytes that will arrive at the serial port's buffer
            };
            // Note that the ReceivedBytesThreshold is set to 1. 
            // That means that the port_DataReceived event will fire with a minimun of 1 byte in the serial buffer
            _port.DataReceived += port_DataReceived;
        }
        void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (e.EventType != SerialData.Chars) return;
            while (_port.IsOpen & _port.BytesToRead != 0)
            {
                // important to get all the bytes off the buffer
                var size = _port.BytesToRead; 
                var buffer = new byte[size];
                var sizeRead = _port.Read(buffer, 0, size);
                OnDataReceived(buffer);
            }
        }
        protected virtual void OnDataReceived(byte[] data)
        {
            var ev = DataReceived;
            if (ev != null) ev(this, new DataReceivedEventArgs(data));
        }
    }
