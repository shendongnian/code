    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.IO.Ports;
    
    namespace canSniff
        {
        class PortDataReceived
        {
    
            private HashSet<string> _messages = new HashSet<string>();
    
            public static void Main()
            {
                SerialPort mySerialPort = new SerialPort("COM4");
    
                mySerialPort.BaudRate = 115200;
                mySerialPort.Parity = Parity.None;
                mySerialPort.StopBits = StopBits.One;
                mySerialPort.DataBits = 8;
                mySerialPort.Handshake = Handshake.None;
                mySerialPort.RtsEnable = true;
    
                mySerialPort.DataReceived += new  SerialDataReceivedEventHandler(DataReceivedHandler);
    
                mySerialPort.Open();
    
                Console.WriteLine("Press any key to continue...");
                Console.WriteLine();
                Console.ReadKey();
    
            }
    
            private static void DataReceivedHandler(
                                object sender,
                                SerialDataReceivedEventArgs e)
            {
                SerialPort sp = (SerialPort)sender;
                string indata = sp.ReadExisting();
    
                if(_messages.Add(indata))
                {
                     // the message was added 
                     Console.WriteLine("Data Received:");
                     Console.Write(indata);
                }
                else
                {
                      // do something with the omitted message that was allready in the list
                }
            }
        }
    }
