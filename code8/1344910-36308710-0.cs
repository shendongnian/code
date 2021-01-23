        // Create the serial port with basic settings....You will need to modify SerialPort("COM3",9600, Parity.None, 8, StopBits.One); to suit your device.
        private SerialPort port = new SerialPort("COM3",
          9600, Parity.None, 8, StopBits.One);
        [STAThread]
        static void Main(string[] args)
        {
            // Instatiate this class
            new SerialPortProgram();
        }
        private SerialPortProgram()
        {
            Console.WriteLine("Incoming Data:");
            // Attach a method to be called when there
            // is data waiting in the port's buffer
            port.DataReceived += new
              SerialDataReceivedEventHandler(port_DataReceived);
            // Begin communications
            port.Open();
            // Enter an application loop to keep this thread alive
            int MyInt = System.Convert.ToInt32(Console.ReadLine());
            byte[] b = BitConverter.GetBytes(MyInt);
            port.Write(b, 0, 4);
            Application.Run();
        }
        private void port_DataReceived(object sender,
          SerialDataReceivedEventArgs e)
        {
            // Show all the incoming data in the port's buffer
            Console.WriteLine(port.ReadExisting());
        }
