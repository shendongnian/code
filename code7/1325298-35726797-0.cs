    List<byte> receivedBinaryData = new List<byte>();
    public void SerialPortDataReceived(object sender, SerialDataReceivedEventArgs e)
    {
        var sp = (SerialPort)sender;
        string availableData = sp.ReadExisting();
        byte[] inputAsASCII = Encoding.ASCII.GetBytes(availableData);
        DBException.WriteLog("");
        DBException.WriteLog("Serial port data received");
        DBException.WriteLog("Read existing = " + availableData);
        try
        {
            // Add the bytes to the receivedBinaryData List
            receivedBinaryData.AddRange(inputAsASCII);
            // If the message length is reached or exceeded, do something
            if (receivedBinaryData.Length >= 4)
               ....
        }
        catch (Exception ex)
        {
            DBException.WriteLog(ex);
        }
    }
