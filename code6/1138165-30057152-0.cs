    public interface IHeadsetLocator
    {
        /// <summary>
        /// Locate all connected audio devices based on the given state.
        /// </summary>
        /// <param name="deviceState"></param>
        /// <returns></returns>
        IReadOnlyCollection<Headset> LocateConnectedAudioDevices(DeviceState deviceState = DeviceState.Active);
    }
