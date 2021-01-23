    using System;
    
    namespace BotAgent.Ifrit.Core.Xml
    {
        using HtmlAgilityPack;
    
        partial class XmlActions
        {
            public class NodeSingle
            {
                private readonly HtmlNode _currNode;
    
                public string Text
                {
                    get
                    {
                        return CleanUpStringFromXml(_currNode.InnerText);
                    }
                }
    
                public string TagName
                {
                    get
                    {
                        return _currNode.OriginalName;
                    }
                }
    
                public string XmlInner
                {
                    get
                    {
                        return _currNode.InnerHtml;
                    }
                }
    
                public string XmlOuter
                {
                    get
                    {
                        return _currNode.OuterHtml;
                    }
                }
    
                public NodeSingle(HtmlNode currentNode)
                {
                    _currNode = currentNode;
                }
    
                public bool Exist()
                {
    
                    if (_currNode == null)
                    {
                        return false;
                    }
    
                    return true;
                }
    
                public bool AttributesExist()
                {
                    return _currNode.HasAttributes;
                }
    
                public bool AttributeExist(string attributeName)
                {
                    if (_currNode.Attributes[attributeName] != null)
                    {
                        return true;
                    }
    
                    return false;
                }
    
                public string AttributeValue(string attrName)
                {
                    return _currNode.GetAttributeValue(attrName, string.Empty);
                }
    
                public bool HaveChildren()
                {
                    var firstChildNode = _currNode.FirstChild;
    
                    if (firstChildNode != null)
                    {
                        return true;
                    }
    
                    return false;
                }
    
                public NodeSingle FirstChild()
                {
                    HtmlNode node = null;
                    try
                    {
                        node = _currNode.ChildNodes[1];
                    }
                    catch (Exception)
                    {
                        //// No need to throw exception, its normal if there are no child
                    }
    
    
                    return new NodeSingle(node);
                }
    
                public NodeSingle Parent()
                {
                    return new NodeSingle(_currNode.ParentNode);
                }
    
                private string CleanUpStringFromXml(string xml)
                {
                    HtmlDocument doc = new HtmlDocument();
                    doc.LoadHtml(xml);
                    var root = doc.DocumentNode;
    
                    root.RemoveAllChildren();
    
                    return root.OuterHtml.Replace(" ", string.Empty);
                }
            }
        }
    }
