       Windows.Devices.WiFiDirect.WiFiDirectDevice wfdDevice;
    private async System.Threading.Tasks.Task<String> Connect(string deviceId)
    {
        string result = ""; 
    
        try
        {
            // No device Id specified.
            if (String.IsNullOrEmpty(deviceId)) { return "Please specify a Wi- Fi Direct device Id."; }
    
            // Connect to the selected Wi-Fi Direct device.
            wfdDevice = await Windows.Devices.WiFiDirect.WiFiDirectDevice.FromIdAsync(deviceId);
    
            if (wfdDevice == null)
            {
                result = "Connection to " + deviceId + " failed.";
            }
    
            // Register for connection status change notification.
            wfdDevice.ConnectionStatusChanged += new TypedEventHandler<Windows.Devices.WiFiDirect.WiFiDirectDevice, object>(OnConnectionChanged);
    
            // Get the EndpointPair information.
            var EndpointPairCollection = wfdDevice.GetConnectionEndpointPairs();
    
            if (EndpointPairCollection.Count > 0)
            {
                var endpointPair = EndpointPairCollection[0];
                result = "Local IP address " + endpointPair.LocalHostName.ToString() + 
                    " connected to remote IP address " + endpointPair.RemoteHostName.ToString();
            }
            else
            {
               result = "Connection to " + deviceId + " failed.";
            }
        }
        catch (Exception err)
        {
            // Handle error.
            result = "Error occurred: " + err.Message;
        }
    
        return result;
    }
    
    private void OnConnectionChanged(object sender, object arg)
    {
        Windows.Devices.WiFiDirect.WiFiDirectConnectionStatus status = 
            (Windows.Devices.WiFiDirect.WiFiDirectConnectionStatus)arg;
    
        if (status == Windows.Devices.WiFiDirect.WiFiDirectConnectionStatus.Connected)
        {
            // Connection successful.
        }
        else
        {
            // Disconnected.
            Disconnect();
        }
    }
    
    private void Disconnect()
    {
        if (wfdDevice != null) 
        {
            wfdDevice.Dispose(); 
        }
    }
