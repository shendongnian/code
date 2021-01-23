    public partial class MyObjectOld : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        private ExtensionDataObjectSerializationProxy extensionDataFieldProxy;
        public ExtensionDataObject ExtensionData
        {
            get
            {
                return extensionDataFieldProxy.ExtensionData; ;
            }
            set
            {
                extensionDataFieldProxy = new ExtensionDataObjectSerializationProxy(value);
            }
        }
    }
