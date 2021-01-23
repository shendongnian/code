    // First create the list of menu items
    int selectedMenuItem = 0;
    List<ToolStripMenuItem> menuItems = new List<ToolStripMenuItem>();
    menuItems.Add(systemManagementToolStripMenuItem);
        
    // When the user performs some action, such as pressing down arrow
    selectedMenuItem = (selectedMenuItem + 1) % menuItems.Count;
    UpdateSelectedItems();
    
    // Have some method to update the buttons
    public void UpdateSelectedItems()
    {
        foreach(var item in menuItems)
            item.BackColor = Color.DarkGray;
        menuItems[selectedMenuItem].BackColor = Color.Gray;
    }
    
    
