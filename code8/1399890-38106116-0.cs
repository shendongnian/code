    private async Task<SerialDevice> initializeSerial()
    {
        try
        {
            string aqs = SerialDevice.GetDeviceSelector("UART0");
            var dis = await DeviceInformation.FindAllAsync(aqs);
            SerialDevice serialPort = await SerialDevice.FromIdAsync(dis[0].Id);
            /* Configure serial settings */
            serialPort.WriteTimeout = TimeSpan.FromMilliseconds(1000);
            serialPort.ReadTimeout = TimeSpan.FromMilliseconds(1000);
            serialPort.BaudRate = 9600;
            serialPort.Parity = SerialParity.None;
            serialPort.StopBits = SerialStopBitCount.One;
            serialPort.DataBits = 8;
            serialPort.Handshake = SerialHandshake.None;
            status.Text = "Serial port configured succesfully.";
            return serialPort;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
        status.Text = "Serial port not configured successfully. Are you sure a serial device is connected?";
        return null;
    }
