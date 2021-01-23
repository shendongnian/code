    class Program
    {
        static bool _continue;
        //Edit here your parameters
        private static SerialPort _serialPort = new SerialPort("COM1", 9600, Parity.None, 8, StopBits.One) {ReadTimeout = 500, WriteTimeout = 500, Handshake = Handshake.None};
        public static void Main()
        {
            string name;
            string message;
            StringComparer stringComparer = StringComparer.OrdinalIgnoreCase;
            
            Thread readThread = new Thread(Read);
            _serialPort.Open();
            readThread.Start();
            _continue = true;
            Console.Write("Name: ");
            name = Console.ReadLine();
            Console.WriteLine("Type QUIT to exit");
            while (_continue)
            {
                message = Console.ReadLine();
                if (stringComparer.Equals("quit", message))
                {
                    _continue = false;
                }
                else
                {
                    _serialPort.WriteLine(String.Format("<{0}>: {1}", name, message));
                }
            }
            _serialPort.Close();
            readThread.Join();
        }
        public static void Read()
        {
            while (_continue)
            {
                try
                {
                    string message = _serialPort.ReadLine();
                    Console.WriteLine(message);
                }
                catch (TimeoutException) { }
            }
        }
    }
