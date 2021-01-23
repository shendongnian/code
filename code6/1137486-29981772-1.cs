    private void LoadElements(XElement xElem, TreeNode treeNode)
    {
        foreach (XElement element in xElem.Elements())
        {
            if (element.HasElements)
            {
                if (element.FirstAttribute != null)
                {
                    TreeNode tempNode = treeNode.Nodes.Add(element.FirstAttribute.Value + "." + element.Attribute("name").Value);
                    LoadElements(element, tempNode);
                }
                else
                {
                    LoadElements(element, treeNode);
                }
            }
            else
                treeNode.Nodes.Add(element.FirstAttribute.Value + "." + element.Attribute("name").Value);
        }
    }
