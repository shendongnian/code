    [ComVisible(true)]
    [Guid("<another-unique-id>")]  // <-- This is what we are going to use for registration
    [ClassInterface(ClassInterfaceType.None)]
    public class TestWindowsCredentialProvider : ITestWindowsCredentialProvider
    {
        private const int E_NOTIMPL = unchecked((int) 0x80004001);
        ...
        public int SetSerialization(ref _CREDENTIAL_PROVIDER_CREDENTIAL_SERIALIZATION pcpcs)
        {
            return E_NOTIMPL;
        }
        ...
    }
