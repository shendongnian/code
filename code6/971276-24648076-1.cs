        public void ClickTreeviewChildItem(string parent, string child)
        {
            // Suppose TreeView control Id is MyTreeView. 
            var treeView = new HtmlDiv(new TreeViewPageMap().UIHttplocalhost38842DeWindow); // Use your uimap window here
            treeView.SearchProperties.Add(HtmlDiv.PropertyNames.Id, "MyTreeView");
            treeView.Find();
            // click on parent
            var parentNode = new HtmlHyperlink(treeView);
            parentNode.SearchProperties.Add(HtmlHyperlink.PropertyNames.InnerText, parent);
            Mouse.Click(parentNode);
            // Get id of plus sign in front of node parent node - should be like "MyTreeViewn9"
            // <tr>
            //  <td><a> - </a> </td>
            //  <td><a> D </a> </td> 
            var expandCollapseIconLink = parentNode.GetParent().GetParent().GetChildren()[0].GetChildren()[0] as HtmlHyperlink;
            var linkId = expandCollapseIconLink.Id;
            // Get child div of clicked parent
            // Child div id will be nothing but suffix "Nodes" attached with the id of expand collapse which we got in previous step
            var childDiv = new HtmlDiv(treeView);
            childDiv.SearchProperties.Add(HtmlDiv.PropertyNames.Id, linkId + "Nodes");
            childDiv.Find();
            // find all links as child links in this div
            var allLink = new HtmlHyperlink(childDiv);
            var allLinks = allLink.FindMatchingControls();
            var linkToClick = allLinks.Cast<HtmlHyperlink>().FirstOrDefault(a => a.InnerText.Trim().Equals(child)); // Using System.Linq;
            Mouse.Click(linkToClick);
        }
