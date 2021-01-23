    public static OperatorNameMessageHeader DeserializeSoap(string xml)
    {
        using (var reader = XmlReader.Create(new StringReader(xml)))
        {
            var m = System.ServiceModel.Channels.Message.CreateMessage(reader, int.MaxValue, MessageVersion.Soap11);
            var operatorNameHeader = m.Headers.GetHeader<OperatorNameMessageHeader>(OperatorNameMessageHeader.HeaderName, OperatorNameMessageHeader.HeaderNamespace);
            return operatorNameHeader;
        }
    }
