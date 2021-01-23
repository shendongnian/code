    class EmptyActionOperationSelector : IDispatchOperationSelector
    {
        Dictionary<XmlQualifiedName, string> dispatchDictionary;
        public EmptyActionOperationSelector(
            Dictionary<XmlQualifiedName, string> dispatchDictionary)
        {
            this.dispatchDictionary = dispatchDictionary;            
        }
        public string SelectOperation(ref System.ServiceModel.Channels.Message message)
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(message.ToString());
            var nsManager = new XmlNamespaceManager(xmlDoc.NameTable);
            nsManager.AddNamespace("soapenv", "http://schemas.xmlsoap.org/soap/envelope/");
            XmlNode node = xmlDoc.SelectSingleNode(
                "/soapenv:Envelope/soapenv:Body", 
                nsManager).FirstChild;
            var lookupQName = new XmlQualifiedName(node.LocalName, node.NamespaceURI);
            return dispatchDictionary.ContainsKey(lookupQName)
                ? dispatchDictionary[lookupQName]
                : node.LocalName;           
        }
    }
