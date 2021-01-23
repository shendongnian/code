    this.listBox1.DrawMode = DrawMode.OwnerDrawFixed;
    this.listBox1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(listBox1_DrawItem);
    listBox1.ItemHeight = 20;
    InstalledFontCollection installedFontCollection = new InstalledFontCollection();
    foreach (FontFamily fontFamily in installedFontCollection.Families)
    {
        FontListItem item = new FontListItem(fontFamily, 10);
        listBox1.Items.Add(item);
    }
