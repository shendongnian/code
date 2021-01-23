    namespace BotAgent.Ifrit.Core.Xml
    {
        using System.Collections.Generic;
        using System.Linq;
        using HtmlAgilityPack;
    
        partial class XmlActions
        {
            public class NodesMultiple
            {
                private readonly HtmlNodeCollection _nodesGroup;
    
                public int Count
                {
                    get
                    {
                        return _nodesGroup.Count;
                    }
                }
    
                public NodesMultiple(HtmlNodeCollection nodesGroup)
                {
                    this._nodesGroup = nodesGroup;
                }
    
                public NodeSingle GetElementByIndex(int index)
                {
                    var singleNode = _nodesGroup.ElementAt(index);
    
                    return new NodeSingle(singleNode);
                }
    
                public List<NodeSingle> GetAll()
                {
                    return _nodesGroup.Select(node => new NodeSingle(node)).ToList();
                }
            }
        }
    }
