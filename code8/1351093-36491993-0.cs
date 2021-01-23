    string[] readText = File.ReadAllLines(@"Path\item.txt");
    foreach (string txt in readText)
    {
        string i = txt.Split(new string[] { "|" }, StringSplitOptions.None)[0];
        ToolStripItem subItem = new ToolStripMenuItem(i);
        var iconImage = new Bitmap(i[1].Replace("/", @"\"));
        subItem.Image = iconImage;
        nToolStripMenuItem.DropDownItems.Add(subItem);
    }
    
