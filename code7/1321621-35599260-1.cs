    private IEnumerable<IDeviceInformationVM> deviceCollection;
    public IEnumerable<IDeviceInformationVM> DeviceCollection 
    {
     get
      {
        return deviceCollection;
      }
      set
      {
        deviceCollection = value; 
        RaisePropertyChanged(() => DisconnectedDevices);
        RaisePropertyChanged(() => DeviceCollection);
      }
    }
    DeviceCollection = GetListOfIDeviceInformationVM(); //will automatically raise property changed and update your TextBlock
