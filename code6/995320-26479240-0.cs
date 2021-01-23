        public static string GetSmallXpath(this GeckoNode node)
        {
            if (node.NodeType == NodeType.Attribute)
            {
                        
                return String.Format("{0}/@{1}", GetSmallXpath(((GeckoAttribute)node).OwnerDocument), node.LocalName);
            }
            if (node.ParentNode == null)
            {
                return "";
            }
            string elementId = ((GeckoHtmlElement) node).Id;
            if (!String.IsNullOrEmpty(elementId))
            {
                return String.Format("//*[@id=\"{0}\"]", elementId);
                
            }
            
            int indexInParent = 1;
            GeckoNode siblingNode = node.PreviousSibling;
            
            while (siblingNode != null)
            {
                
                if (siblingNode.LocalName == node.LocalName)
                {
                    indexInParent++;
                }
                siblingNode = siblingNode.PreviousSibling;
            }
              
            return String.Format("{0}/{1}[{2}]", GetSmallXpath(node.ParentNode), node.LocalName, indexInParent);
        }
        public static string GetXpath(this GeckoNode node)
        {
            if (node.NodeType == NodeType.Attribute)
            {
                       
                return String.Format("{0}/@{1}", GetXpath(((GeckoAttribute)node).OwnerDocument), node.LocalName);
            }
            if (node.ParentNode == null)
            {
                
                return "";
            }
            
            
            int indexInParent = 1;
            GeckoNode siblingNode = node.PreviousSibling;
           
            while (siblingNode != null)
            {
                
                if (siblingNode.LocalName == node.LocalName)
                {
                    indexInParent++;
                }
                siblingNode = siblingNode.PreviousSibling;
            }
    
            return String.Format("{0}/{1}[{2}]", GetXpath(node.ParentNode), node.LocalName, indexInParent);
        }
