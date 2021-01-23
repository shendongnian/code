     public static string TraverseNodes(XmlNode node,XmlDocument xmlDoc,bool isChild)
        {
            XmlAttribute typeAttr = xmlDoc.CreateAttribute("realIndex");
            typeAttr.Value = (isChild ? (i+ ".") : "") + (i + 1);
            node.Attributes.Append(typeAttr);
            foreach (XmlNode subNode in node)
            {
                TraverseNodes(subNode, xmlDoc, isChild);
            }
            return PrintXml(xmlDoc);
        }
