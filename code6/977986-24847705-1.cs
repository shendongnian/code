    // edit - I forgot to show GetCameraID:
    private static async Task<DeviceInformation> GetCameraID(Windows.Devices.Enumeration.Panel desiredCamera)
    {
        DeviceInformation deviceID = (await DeviceInformation.FindAllAsync(DeviceClass.VideoCapture))
            .FirstOrDefault(x => x.EnclosureLocation != null && x.EnclosureLocation.Panel == desiredCamera);
        if (deviceID != null) return deviceID;
        else throw new Exception(string.Format("Camera of type {0} doesn't exist.", desiredCamera));
    }
    // init camera
    async private void InitCameraBtn_Click(object sender, RoutedEventArgs e)
    {
        var cameraID = await GetCameraID(Windows.Devices.Enumeration.Panel.Back);
        captureManager = new MediaCapture();
        await captureManager.InitializeAsync(new MediaCaptureInitializationSettings
            {
                StreamingCaptureMode = StreamingCaptureMode.Video,
                PhotoCaptureSource = PhotoCaptureSource.VideoPreview,
                AudioDeviceId = string.Empty,
                VideoDeviceId = cameraID.Id
            });
    }
    // then to turn on/off camera
    var torch = captureManager.VideoDeviceController.TorchControl;
    if (torch.Supported) torch.Enabled = true;
    // turn off
    if (torch.Supported) torch.Enabled = true;
