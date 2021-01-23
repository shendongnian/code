    //connects to the selected com port
    private async void comConnect_Click(object sender, RoutedEventArgs e)
    {
        _key = 0;
        status2.Text = "";
        string aqs = SerialDevice.GetDeviceSelector(ConnectDevices.SelectedItem.ToString());
        var dlist = await DeviceInformation.FindAllAsync(aqs);
        if (dlist.Count <= 0)
        {
            status.Text = "No devices found.";
            return;
        }
        try
        {
            // NOTE: possible infinite loop!
            do
            {
                serialPort = await SerialDevice.FromIdAsync(dlist[0].Id);
                status.Text = "Connecting to serial port...";
            } while (serialPort == null);
            // Configure serial settings
            serialPort.WriteTimeout = TimeSpan.FromMilliseconds(1000);
            serialPort.BaudRate = 38400;
            serialPort.Parity = SerialParity.None;
            serialPort.StopBits = SerialStopBitCount.One;
            serialPort.DataBits = 8;
            serialPort.Handshake = SerialHandshake.None;
            status.Text = "Serial port configured successfully.";
            // Perform other serial logic... 
        }
        catch (Exception ex)
        {
            status.Text = ex.Message;
        }
        finally
        {
            if(serialPort != null)
            {
                serialPort.Dispose();
                serialPort = null;
            }
        }
    }
