    [ComImport]
    [Guid("A95664D2-9614-4F35-A746-DE8DB63617E6")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IMMDeviceEnumerator
    {
        // etc..
    }
    
    public static class MMDeviceEnumeratorFactory {
        private static readonly Guid MMDeviceEnumerator = new Guid("BCDE0395-E52F-467C-8E3D-C4579291692E");
        public static IMMDeviceEnumerator CreateInstance() {
            var type = Type.GetTypeFromCLSID(MMDeviceEnumerator);
            return (IMMDeviceEnumerator)Activator.CreateInstance(type);
        }
    }
