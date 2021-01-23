    class MySerialPort
    {
        private ManualResetEventSlim _waithandle = new ManualResetEventSlim(true);
        private SerialPort _serialPort;
        private readonly object _sync = new object();
        public void write(string message)
        {
            lock (_sync)
            {
                _waithandle.Wait();
                //Stuff
                _serialPort.Write(message);
                _waithandle.Reset();
            }
        }
        public string read()
        {
            try
            {
             ....
            }
            finally
            {
                _waithandle.Set();
            }
        }
    }
