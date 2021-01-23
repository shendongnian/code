    string strNodesToHide = "100, 500, 900";
    
    SiteMapNode node = e.Node.DataItem as SiteMapNode;
    
    if (node["securityLevel"].length != 0) {
      if (strNodesToHide.indexOf("securityLevel") > -1) {
        e.Node.Parent.ChildNodes.Remove(e.Node);
      }
    }
