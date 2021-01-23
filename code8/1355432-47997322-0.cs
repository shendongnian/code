    [Guid("5CDF2C82-841E-4546-9722-0CF74078229A"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IAudioEndpointVolume
    {
        // ...
        Int32 SetMasterVolumeLevel(float fLevelDB, Guid pguidEventContext);
        Int32 SetMasterVolumeLevelScalar(float fLevel, Guid pguidEventContext);
        // ...
    }
