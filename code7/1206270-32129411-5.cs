    public partial class MyObject : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        private ExtensionDataObjectSerializationProxy extensionDataField; // Use the proxy not ExtensionDataObject directly
        public ExtensionDataObject ExtensionData
        {
            get
            {
                return extensionDataField;
            }
            set
            {
                extensionDataField = value;
            }
        }
    }
