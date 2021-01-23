    private string GetIMEINumber(string PortName) //Serial
    {
        string key = "";
        SerialPort serialPort = new SerialPort();
        serialPort.PortName = PortName;
        serialPort.BaudRate = 9600;
        try
        {
            if (!(serialPort.IsOpen))
                serialPort.Open();
            serialPort.Write("AT\r\n");
            Thread.Sleep(3000);
            key = serialPort.ReadExisting();
            serialPort.Write("AT+CGSN\r\n");
            Thread.Sleep(3000);
            key = serialPort.ReadExisting();
            serialPort.Close();
            string Serial = "";
            for (int i = 0; i < key.Length; i++)
                if (char.IsDigit(key[i]))
                    Serial += key[i];
            return Serial;
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error in opening/writing to serial port :: " + ex.Message, "Error!");
            return "";
        } 
    } 
