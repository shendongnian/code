    protected void Page_Load(object sender, EventArgs e)
    {
    
        // Create Accordion Pane Header Content
        divMenu.InnerHtml = "<div class='tab_container' id='tab_container'>";
    
        foreach (SiteMapNode node in SiteMap.RootNode.ChildNodes)
        {
            // Header
            //Check whether is first node
            if (SiteMap.RootNode.ChildNodes.Count == 0)
            {
                // Create header html
                divMenu.InnerHtml += "<h3 class='d_active tab_drawer_heading' rel='" + node.Title + "'>" + node.Title + "</h3>";          
            }
            else
            {
                divMenu.InnerHtml += "<h3 class='tab_drawer_heading' rel='" + node.Title + "'>" + node.Title + "</h3>";
            }
    
            // Create header html
            divMenu.InnerHtml += "<div id='" + node.Title + "' class='tab_content' style='display: block;'>";
    
            // Content
            foreach (SiteMapNode child in node.ChildNodes)
            {
                // Check Role Access Right
                if (CheckRolePermission(ConstantValues.MAINTENANCEMODE_VIEW, GetFunctionNameByTitle(child.Title)))
                {
                    // Create content html
                    divMenu.InnerHtml += "<p>" + child.Title + "</p>";
                }
            }
    		
    		divMenu.InnerHtml += "</div>";
        }
    
        divMenu.InnerHtml += "</div>";
    
    }
