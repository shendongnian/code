    public class MySerialPort: IComPort, IDisposable {
        SerialPort _serialPort;
        public MotorComPort(String portName, int baudrate, Parity parity, int databits, 
                            StopBits stopbits)
        {
            _serialPort = new SerialPort(portName, baudrate, parity, databits, stopbits);
        }
        // ...
    }
