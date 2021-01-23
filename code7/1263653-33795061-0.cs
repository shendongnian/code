    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.IO.Ports;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                SerialPort port = new SerialPort("COM3", 19200, Parity.None, 8, StopBits.One);
                 
                Byte[] data =  File.ReadAllBytes("myFile.plt");
                port.Write(data, 0, data.Count());
            }
        }
    }
    ​
