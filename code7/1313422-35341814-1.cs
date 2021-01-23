    Dim xml = IO.File.ReadAllText(masterLangDir)
    Dim xdoc = New XmlDocument()
    xdoc.LoadXml(xml)
    Dim xPaths = findAllNodes(xdoc.SelectSingleNode("content"), New List(Of String))
    public List<string> findAllNodes(XmlNode node, List<string> xPaths)
    {
    	foreach (XmlNode n in node.ChildNodes) {
    		var checkForChildNodes = true;
    		if (n.Attributes != null) {
    			if (n.Attributes("editable") != null) {
    				if (n.Attributes("editable").Value == "true") {
    					xPaths.Add(GetXPathToNode(n));
    					checkForChildNodes = false;
    				}
    			}
    		}
    		if (checkForChildNodes) {
    			xPaths = findAllNodes(n, xPaths);
    		}
    	}
    	return xPaths;
    }
    public string GetXPathToNode(XmlNode node)
    {
    	if (node.NodeType == XmlNodeType.Attribute) {
    		// attributes have an OwnerElement, not a ParentNode; also they have             
    		// to be matched by name, not found by position             
    		return String.Format("{0}/@{1}", GetXPathToNode(((XmlAttribute)node).OwnerElement), node.Name);
    	}
    	if (node.ParentNode == null) {
    		// the only node with no parent is the root node, which has no path
    		return "";
    	}
    
    	// Get the Index
    	int indexInParent = 1;
    	XmlNode siblingNode = node.PreviousSibling;
    	// Loop thru all Siblings
    	while (siblingNode != null) {
    		// Increase the Index if the Sibling has the same Name
    		if (siblingNode.Name == node.Name) {
    			indexInParent += 1;
    		}
    		siblingNode = siblingNode.PreviousSibling;
    	}
    
    	// the path to a node is the path to its parent, plus "/node()[n]", where n is its position among its siblings.         
    	return String.Format("{0}/{1}[{2}]", GetXPathToNode(node.ParentNode), node.Name, indexInParent);
    }
