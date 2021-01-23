    class NotificationClient : NAudio.CoreAudioApi.Interfaces.IMMNotificationClient
    {
        void IMMNotificationClient.OnDeviceStateChanged(string deviceId, DeviceState newState)
        {
            Console.WriteLine("OnDeviceStateChanged\n Device Id -->{0} : Device State {1}", deviceId, newState);
        }
        void IMMNotificationClient.OnDeviceAdded(string pwstrDeviceId) { }
        void IMMNotificationClient.OnDeviceRemoved(string deviceId) { }
        void IMMNotificationClient.OnDefaultDeviceChanged(DataFlow flow, Role role, string defaultDeviceId) { }
        void IMMNotificationClient.OnPropertyValueChanged(string pwstrDeviceId, PropertyKey key) { }
    }
