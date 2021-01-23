    using NAudio.CoreAudioApi;
    
    MMDeviceEnumerator names = new MMDeviceEnumerator();
    var devices = names.EnumerateAudioEndPoints(DataFlow.Capture, DeviceState.Active);            
    foreach (var device in devices)
        MessageBox.Show(device.friendlyName);
