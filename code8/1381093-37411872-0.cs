    public VideoCaptureDeviceInformation SelectedCameraDevice
    {
        get { return _selectedCameraDevice; }
        set
        {
             var oldVal = _selectedCameraDevice;
             _selectedCameraDevice = value;
             OnPropertyChanged("SelectedCameraDevice");
             if (oldVal != null)
             {
                 SelectedCameraDevice_Changed();
             }
        }
    }
