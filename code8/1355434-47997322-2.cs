    [Guid("5CDF2C82-841E-4546-9722-0CF74078229A"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IAudioEndpointVolume
    {
        // ...
        Int32 GetMasterVolumeLevelScalar(ref Single pfLevel);
        Int32 SetMasterVolumeLevelScalar(Single fLevel, Guid pguidEventContext);
        // ...
    }
