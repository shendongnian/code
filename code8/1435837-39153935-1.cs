    using System.IO.Ports;
    using System.Management;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ROOT.CIMV2.Win32;
    namespace Modem
    {
        class Program
        {
        public static string portName;
        public static SerialPort _serialPort;
        static void Main(string[] args)
        {
            foreach (POTSModem modem in POTSModem.GetInstances())
            {
                if (modem.Description.Contains("WWAN"))
                {
                    portName = modem.AttachedTo;
                    
                    SetPort();
                    break;
                }
            }
         }
     public static void SetPort()
        {
            //Assign the port to a COM address and a Baud rate
            _serialPort = new SerialPort(portName, 9600);
            //Open the connection
            _serialPort.Open();
            // Makes sure serial port is open before trying to write
            try
            {
                //If the port is not open
                if (!(_serialPort.IsOpen))
                    //Open it
                    _serialPort.Open();
            }
            catch
            {
                Console.WriteLine("ERROR! Couldn't open serial port...");
                Console.ReadKey();
            }
            try
            {
                //Here it executes a command on the modem
                _serialPort.Write("ATI\r");
                //Retrieves the output, setting the value to a string
                string indata = _serialPort.ReadExisting();
                Console.WriteLine(indata);
            }
            catch
            {
                Console.WriteLine("ERROR GETTING INFO!!!");
                Console.ReadKey();
            }
         }
      }
    }
