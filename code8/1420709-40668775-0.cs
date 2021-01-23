        // delegate is used to write to a UI control from a non-UI thread
        private delegate void SetTextDeleg(string text);
        private void Form1_Load(object sender, EventArgs e)
        {
            // all of the options for a serial device
            // can be sent through the constructor of the SerialPort class
            // PortName = "COM1", Baud Rate = 19200, Parity = None, 
            // Data Bits = 8, Stop Bits = One, Handshake = None
            //_serialPort = new SerialPort("COM8", 19200, Parity.None, 8, StopBits.One);
            _serialPort = new SerialPort("COM8", 19200, Parity.None, 8, StopBits.One);
            _serialPort.Handshake = Handshake.None;
            _serialPort.DataReceived += new SerialDataReceivedEventHandler(sp_DataReceived);
            _serialPort.ReadTimeout = 500;
            _serialPort.WriteTimeout = 500;
            _serialPort.Open();
        }
