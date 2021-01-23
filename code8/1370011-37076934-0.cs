    readonly object _lock = new object();
    SerialPort _serialPort;
    string _text = "";
    
    public void Init()
    {
        _serialPort = new SerialPort("COM1", 19200, Parity.Space, 8, StopBits.One);
        _serialPort.ParityReplace = 0;
        _serialPort.DataReceived += DataReceived;
        _serialPort.ErrorReceived += ErrorReceived;
        _serialPort.Open();
    }
    void DataReceived(object sender, SerialDataReceivedEventArgs e)
    {
        DumpToHexString();
    }
    
    void ErrorReceived(object sender, SerialErrorReceivedEventArgs e)
    {
        if (e.EventType == SerialError.RXParity)
            DumpToHexString();
    }
    
    void DumpToHexString()
    {
        lock (_lock)
        {
            while (_serialPort.BytesToRead > 0)
            {
                var chunk = new byte[_serialPort.BytesToRead];
                _serialPort.Read(chunk, 0, chunk.Length);
                _text += ByteToHex(chunk);
            }
        }        
        this.BeginInvoke(new Action(() => txtMessage.Text = _text));
    }
