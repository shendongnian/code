    internal static class ComObjectFactory
    {
    
        public static IMultimediaDeviceEnumerator GetDeviceEnumerator()
        {
            return Activator.CreateInstance(Type.GetTypeFromCLSID(new Guid(ComIIds.DEVICE_ENUMERATOR_CID))) as IMultimediaDeviceEnumerator;
        }
    
    }
