        public class ReceiptsHeader : MessageHeader
    {
        private const string HeaderName = "Receipts";
        private const string HeaderNamespace = "http://MyCompany/abc";
        public override string Name => HeaderName;
        public override string Namespace => HeaderNamespace;
        private readonly XmlDocument _usageReceipt = new XmlDocument();
        public ReceiptsHeader(IEnumerable elements)
        {
            var headerString = new StringBuilder("<Receipts xmlns=\"http://MyCompany/abc\">");
            foreach (var elem in elements)
            {
                // Build <Receipt> nodes here...
            }
            headerString.Append("</Receipts>");
            _usageReceipt.LoadXml(headerString.ToString());
        }
        protected override void OnWriteHeaderContents(XmlDictionaryWriter writer, MessageVersion messageVersion)
        {
            foreach (XmlNode node in _usageReceipt.ChildNodes[0].ChildNodes)
                writer.WriteNode(node.CreateNavigator(), false);
        }
    }
