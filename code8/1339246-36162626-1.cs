        protected override void OnWriteHeaderContents(XmlDictionaryWriter writer, MessageVersion messageVersion)
        {
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("wsu", TimeStamp.WsuNamespace);
            XmlSerializer serializer1 = new XmlSerializer(typeof(TimeStamp));
            serializer1.Serialize(writer, new TimeStamp(), ns);
        }
