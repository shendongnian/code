    public class SerialPortA : SerialPort
    {
       public string DeviceType { get; set; }
       public SerialPortA(string portName, int baudRate, Parity parity, int dataBits, StopBits stopBits, string deviceType)
           : this()
       {
           //...
       }
       //...
    }
    private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
    { 
        if ((sender as SerialPortA).DeviceType == "Analyzer 1")
        {
            //...
        }
    }
