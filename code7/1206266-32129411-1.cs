    public partial class MyObjectOld : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        private ExtensionDataObjectSerializationProxy extensionDataFieldProxy;
        public ExtensionDataObject ExtensionData
        {
            get
            {
                return extensionDataFieldProxy == null ? null : extensionDataFieldProxy.ExtensionData; ;
            }
            set
            {
                if (value == null)
                    extensionDataFieldProxy = null;
                else
                    extensionDataFieldProxy = new ExtensionDataObjectSerializationProxy { ExtensionData = value };
            }
        }
    }
