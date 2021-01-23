    private void OpenTextFile(string id)
    {
        //TODO: logic for opening the shared file
    }
    private void CreateMenu()
    {
        ToolStripMenuItem item = new ToolStripMenuItem();
        item.Text = "Logs";
        DirectoryInfo dir = new DirectoryInfo(@"Y:\Heineken\Tools\Logs\");
        foreach (DirectoryInfo directory in dir.GetDirectories())
        {
            ToolStripMenuItem dateItem = new ToolStripMenuItem(directory.Name);
            ToolStripMenuItem NLMenu = new ToolStripMenuItem("NL", null, (sender, e) => OpenTextFile("NL"));
            ToolStripMenuItem PLMenu = new ToolStripMenuItem("PL", null, (sender, e) => OpenTextFile("PL"));
            dateItem.DropDownItems.Add(NLMenu);
            dateItem.DropDownItems.Add(PLMenu);
            item.DropDownItems.Add(dateItem);
        }
        menuToolStripMenuItem.DropDownItems.Add(item);
    }
