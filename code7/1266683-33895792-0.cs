                xNode = inXmlNode.ChildNodes[i];
                TreeNode childTreeNode;
                if (xNode.LocalName == "action")
                {
                  childTreeNode = new TreeNode(xNode.GetAttribute("name"));
                }
                else
                {
                  childTreeNode = new TreeNode(xNode.Name);
                }
                
                inTreeNode.Nodes.Add(childTreeNode);
