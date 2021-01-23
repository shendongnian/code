    namespace BotAgent.Ifrit.Core.Xml
    {
        using HtmlAgilityPack;
    
        public partial class XmlActions
        {
            private HtmlDocument _xmlDoc;
            private HtmlNode _rootNode;
            public XmlActions()
            {
                _xmlDoc = new HtmlDocument();
            }
    
            private void Update()
            {
                string pageSource = Brwsr.CurrPage.PageSource.Replace("\r\n", string.Empty);
    
                _xmlDoc.LoadHtml(pageSource);
                _rootNode = _xmlDoc.DocumentNode;
            }
    
            public NodeSingle Elmnt(string xpath)
            {
                Update();
    
                var currNode = _rootNode.SelectSingleNode(xpath);
    
                return new NodeSingle(currNode);
            }
    
            public NodesMultiple Elmnts(string xpath)
            {
                Update();
    
                var nodesGroup = _rootNode.SelectNodes(xpath);
    
                return new NodesMultiple(nodesGroup);
            }
        }
    }
