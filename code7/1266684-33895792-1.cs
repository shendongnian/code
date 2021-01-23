                xNode = inXmlNode.ChildNodes[i];
                TreeNode childTreeNode;
                if (xNode.LocalName == "action" && xNode.NodeType == XmlNodeType.Element)
                {
                  childTreeNode = new TreeNode(xNode.Attributes["name"].Value);
                }
                else
                {
                  childTreeNode = new TreeNode(xNode.Name);
                }
                
                inTreeNode.Nodes.Add(childTreeNode);
