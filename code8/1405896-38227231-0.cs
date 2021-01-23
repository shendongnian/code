    var rightClickCell = new Action(() => Mouse.Click(cell1, MouseButtons.Right, ModifierKeys.None, new Point(125, 10)));
    var contextMenu = new WinList(uIContextMenu);
    var pasteMenuItem = new WinButton(contextMenu);
    pasteMenuItem.SearchProperties[WinButton.PropertyNames.Name] = "Paste";
    rightClickCell();
    while (!pasteMenuItem.TryFind() || !pasteMenuItem.Enabled)
    {
        Mouse.Click(cell1, new Point(10, 10));
        rightClickCell();
        Thread.Sleep(5000);
    }
    if (pasteMenuItem.Enabled)
    {
        pasteMenuItem.DrawHighlight();
        Mouse.Click(pasteMenuItem, new Point(10, 10));
    }
