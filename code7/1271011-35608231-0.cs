    void IMMNotificationClient.OnDeviceStateChanged(string deviceId, DeviceState newState) {
        Console.WriteLine("OnDeviceStateChanged\n Device Id -->{0} : Device State {1}", deviceId, newState);
        var endp = new NAudio.CoreAudioApi.MMDeviceEnumerator().GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia);
        bool isHeadPhone = false;
        PropertyKey key = PropertyKeys.PKEY_AudioEndpoint_FormFactor;
        var store = endp.Properties;
        for (var index = 0; index < store.Count; index++) {
            if (store.Get(index).Equals(key)) {
                var value = (uint)store.GetValue(index).Value;
                const uint formHeadphones = 3;
                const uint formHeadset = 5;
                if (value == formHeadphones || value == formHeadset) {
                    isHeadPhone = true;
                    break;
                }
            }
        }
        // Use isHeadPhone
        // etc...
    }
