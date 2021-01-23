    // <summary>
    // Creates the context menu when the selected item is a folder.
    // </summary>
    protected void MenuDirectory()
    {
        ToolStripMenuItem MainMenu;
        MainMenu = new ToolStripMenuItem
        {
            Text = "MenuDirectory",
            Image = Properties.Resources.Folder_icon
        };
                ToolStripMenuItem SubMenu1;
                SubMenu1 = new ToolStripMenuItem
                {
                    Text = "DirSubMenu1",
                    Image = Properties.Resources.Folder_icon
                };
                var SubMenu2 = new ToolStripMenuItem
                {
                    Text = "DirSubMenu2",
                    Image = Properties.Resources.Folder_icon
                };
                SubMenu2.DropDownItems.Clear();
                SubMenu2.Click += (sender, args) => ShowItemName();
                        var SubSubMenu1 = new ToolStripMenuItem
                        {
                            Text = "DirSubSubMenu1",
                            Image = Properties.Resources.Folder_icon
                        };
                        SubSubMenu1.Click += (sender, args) => ShowItemName();
        
        // Let's attach the submenus to the main menu
        SubMenu1.DropDownItems.Add(SubSubMenu1);
        MainMenu.DropDownItems.Add(SubMenu1);
        MainMenu.DropDownItems.Add(SubMenu2);
        menu.Items.Clear();
        menu.Items.Add(MainMenu);
    }
