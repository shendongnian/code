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
