    var rightClickCell = () => Mouse.Click(Cell1, MouseButtons.Right, ModifierKeys.None, new Point(125, 10));
    // pseudo code
    var contextMenu = new WinContextMenu(Cell1);
    var pasteMenuItem = new WinMenuItem(contextMenu);
    pasteMenuItem.SearchProperties.Add("Name", "Paste");
    rightClickCell();
    while(!pasteMenuItem.TryFind() || !pasteMenuItem.Enabled)
    {
       rightClickCell();
       WaitForControlEnabled(pasteMenuItem, 10 * 1000);
    }
    if(pasteMenuItem.Enabled)
    {
       Mouse.Click(pasteMenuItem);
    }
