    class MySerialPort
    {
        private int _waitCounter;
        private AutoResetEvent _waithandle;
        private SerialPort _serialPort;
        public void write(string message)
        {
            if (Interlocked.Increment(ref _waitCounter) != 1)
                _waithandle.WaitOne();
            //Stuff
            _serialPort.Write(message);
        }
        public string read()
        {
            ...
            Interlocked.Decrement(ref _waitCounter);
            _waithandle.Set();
        }
    }
