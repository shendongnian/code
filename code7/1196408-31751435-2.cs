    public static string AssignIndex(XmlNode node, int nodeIdx, int childIdx)
        {
            if (childIdx != 0) {
                XmlAttribute typeAttr = xmlDoc.CreateAttribute("realIndex");
                typeAttr.Value = (nodeIdx == 0 ? "": (nodeIdx+ ".")) + childIdx;
                node.Attributes.Append(typeAttr);
            }
            int i=1;
            foreach (XmlNode subNode in node.ChildNodes)
            {
                AssignIndex(subNode, childIdx, i++);
            }
        }
