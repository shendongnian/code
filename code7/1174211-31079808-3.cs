    class MySerialPort
    {
        private AutoResetEvent _waithandle = new AutoResetEvent(true);
        private SerialPort _serialPort;
        public void write(string message)
        {
            _waithandle.WaitOne();
            //Stuff
            _serialPort.Write(message);
        }
        public string read()
        {
            try
            {
               ...
               ...
            }
            finally
            {
                _waithandle.Set();
            }
        }
    }
