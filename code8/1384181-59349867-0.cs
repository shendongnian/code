    //lists com ports
    private async void listPorts()
    {
        try
        {
            string aqs = SerialDevice.GetDeviceSelector();
            var dlist = await DeviceInformation.FindAllAsync(aqs);
            status.Text = "Select a device and connect";
            for (int i = 0; i < dlist.Count; i++)
            {
                using(var port = await SerialDevice.FromIdAsync(dlist[0].Id))
                {
                    ConnectDevices.Items.Add(port.PortName);
                }
            }
            comConnect.IsEnabled = true;
            ConnectDevices.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            status.Text = ex.Message;
        }
    }
