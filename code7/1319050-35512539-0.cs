    class Program
    {
        private static SerialPort _SerialPort;
        private const int baudRate = 9600;
        private const string PortName = "Com4";
        static void Main(string[] args)
        {
            _SerialPort = new SerialPort(PortName, baudRate);
            _SerialPort.DataReceived += _readSerialPort_DataReceived;
            _SerialPort.Open();
           var command = new byte[] { 0x1B, 0x81 };
           Console.WriteLine("Sending {0} to device", command);
           sendData(command);
            Console.WriteLine("Press any key to continue...");
            Console.WriteLine();
            Console.ReadKey();
            _SerialPort.Close();
        }
        static void sendData(byte[] command)
        {
            _SerialPort.Write(command,0,command.Length);
        }
        static void _readSerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            var sp = (SerialPort) sender;
            var data = sp.ReadExisting();
            Console.WriteLine("Data Received: {0}", data);
            //if you are going to update the UI you need to invoke a delegate method on the main thread
        }
    }
