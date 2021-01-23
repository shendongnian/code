    [__DynamicallyInvokable]
        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        public static XDocument Load(Stream stream)
        {
          return XDocument.Load(stream, LoadOptions.None);
        }
    
        [__DynamicallyInvokable]
        public static XDocument Load(Stream stream, LoadOptions options)
        {
          XmlReaderSettings xmlReaderSettings = XNode.GetXmlReaderSettings(options);
          using (XmlReader reader = XmlReader.Create(stream, xmlReaderSettings))
            return XDocument.Load(reader, options);
        }
