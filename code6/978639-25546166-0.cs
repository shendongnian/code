    public VideoCaptureDevice source;
    private IAMCameraControl cameraControls;
    
    ...
    // Match specified camera name to device
    FilterInfoCollection videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
    for (int i = 0, n = videoDevices.Count; i < n; i++)
    {
        if (name == videoDevices[i].Name)
        {
            moniker = videoDevices[i].MonikerString;
            break;
        }
    }
    source = new VideoCaptureDevice(moniker);
    cameraControls = (IAMCameraControl)source.SourceObject;
    
    cameraControls.Set(CameraControlProperty.Exposure, -11, CameraControlFlags.Manual);
