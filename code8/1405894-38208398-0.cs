    var rightClickCell = () => Mouse.Click(Cell1, MouseButtons.Right, ModifierKeys.None, new Point(125, 10));
    rightClickCell();
    while (!PasteButton.Enabled);
    {
        System.Threading.Thread.Sleep(10000);
        rightClickCell();
    }
    if (PasteButton.Enabled)
    {
        // PROBABLY DO NOT WHAT TO DO THIS
        // instead, find the context menu and click the item
        // whose name/text is "Paste"
        Mouse.Click(Cell1, new Point(54, 12));
    }
