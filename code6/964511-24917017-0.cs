            SPSite siteCollection1 = new SPSite(<site>);
            
            SPWeb myWebs = siteCollection1.OpenWeb();
            foreach (SPWeb webItem in myWebs.Webs)
            {
                SPFile myFile = webItem.GetFile("default.aspx");
                SPLimitedWebPartManager limitedWebPartManager = myFile.GetLimitedWebPartManager(System.Web.UI.WebControls.WebParts.PersonalizationScope.Shared);
                // Get all web parts that are available on the default.aspx page
                SPLimitedWebPartCollection webParts = limitedWebPartManager.WebParts;
                // Loop through the collection of all web parts on the page
                foreach (System.Web.UI.WebControls.WebParts.WebPart webPartOnPage in webParts)
                {
                    // Only try to set the toolbar type is the web part is a ListViewWebPart, other web part types don't have toolbars
                    if (webPartOnPage.GetType().Name == "ListViewWebPart")
                    {
                        ListViewWebPart listViewWebPart = webPartOnPage as ListViewWebPart;
                        // Get the view used in the web part by using reflection
                        PropertyInfo viewProp = listViewWebPart.GetType().GetProperty("View", BindingFlags.NonPublic | BindingFlags.Instance);
                        SPView webPartView = viewProp.GetValue(listViewWebPart, null) as SPView;
                        // This is necessary after the infrastructure update, without it you can't get to the XML of the view
                        webPartView.GetType().InvokeMember("EnsureFullBlownXmlDocument", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.InvokeMethod, null, webPartView, null, System.Globalization.CultureInfo.CurrentCulture);
                        PropertyInfo nodeProp = webPartView.GetType().GetProperty("Node", BindingFlags.NonPublic | BindingFlags.Instance);
                        XmlNode node = nodeProp.GetValue(webPartView, null) as XmlNode;
                        // Get the toolbar node from the XML of the view used in the web part
                        XmlNode toolbarNode = node.SelectSingleNode("Toolbar");
                        if (toolbarNode != null)
                        {
                            toolbarNode.InnerXml = toolbarNode.InnerXml.Replace("?RootFolder", "&amp;RootFolder");
                            webPartView.Update();
                        }
                    }
                }
            }
