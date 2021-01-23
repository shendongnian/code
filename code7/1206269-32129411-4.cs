    [Serializable]
    public struct ExtensionDataObjectSerializationProxy : ISerializable
    {
        public static implicit operator ExtensionDataObjectSerializationProxy(ExtensionDataObject data) { return new ExtensionDataObjectSerializationProxy(data); }
        public static implicit operator ExtensionDataObject(ExtensionDataObjectSerializationProxy proxy) { return proxy.ExtensionData; }
        private readonly System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        public ExtensionDataObject ExtensionData { get { return extensionDataField; } }
        [DataContract(Name = "ExtensionData", Namespace = "")]
        sealed class ExtensionDataObjectSerializationContractProxy : IExtensibleDataObject
        {
            private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
            #region IExtensibleDataObject Members
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
            #endregion
        }
        public ExtensionDataObjectSerializationProxy(ExtensionDataObject extensionData)
        {
            this.extensionDataField = extensionData;
        }
        public ExtensionDataObjectSerializationProxy(SerializationInfo info, StreamingContext context)
        {
            var xml = (string)info.GetValue("ExtensionData", typeof(string));
            if (!string.IsNullOrEmpty(xml))
            {
                var wrapper = DataContractSerializerHelper.LoadFromXML<ExtensionDataObjectSerializationContractProxy>(xml);
                extensionDataField = (wrapper == null ? null : wrapper.ExtensionData);
            }
            else
            {
                extensionDataField = null;
            }
        }
        #region ISerializable Members
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (ExtensionData != null)
            {
                var xml = DataContractSerializerHelper.GetXml(new ExtensionDataObjectSerializationContractProxy { ExtensionData = this.ExtensionData });
                info.AddValue("ExtensionData", xml);
            }
            else
            {
                info.AddValue("ExtensionData", (string)null);
            }
        }
        #endregion
    }
    public static class DataContractSerializerHelper
    {
        public static string GetXml<T>(T obj, DataContractSerializer serializer = null)
        {
            using (var textWriter = new StringWriter())
            {
                using (var xmlWriter = XmlWriter.Create(textWriter))
                {
                    (serializer ?? new DataContractSerializer(typeof(T))).WriteObject(xmlWriter, obj);
                }
                return textWriter.ToString();
            }
        }
        private static MemoryStream GenerateStreamFromString(string value)
        {
            return new MemoryStream(Encoding.Unicode.GetBytes(value ?? ""));
        }
        public static T LoadFromXML<T>(string xml, DataContractSerializer serializer = null)
        {
            using (var stream = GenerateStreamFromString(xml))
            {
                return (T)(serializer ?? new DataContractSerializer(typeof(T))).ReadObject(stream);
            }
        }
    }
