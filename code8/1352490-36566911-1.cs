    using NAudio.CoreAudioApi;
    MMDeviceEnumerator enumerator = new MMDeviceEnumerator();
    var devices = enumerator.EnumerateAudioEndPoints(DataFlow.Capture, DeviceState.Active);            
    foreach (var device in devices)
        MessageBox.Show(device.friendlyName);
