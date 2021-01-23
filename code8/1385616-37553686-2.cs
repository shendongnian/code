    private readonly object _sync = new object();
    private readonly List<string> _receivedCodes = new List<string>();
    private void SerialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
    {
        var readValue = (serialPort1.ReadLine() ?? string.Empty).Trim(); //reads serial  
        if (!string.IsNullOrEmpty(readValue))
        {
            lock (_sync) _receivedCodes.Add(readValue);
            lastValue = readValue;
        } 
    } 
