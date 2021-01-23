    var stackPanel = new StackPanel
    {
        Orientation = Orientation.Horizontal
    };
    stackPanel.Children.Add(new SymbolIcon
    {
        Width = 48,
        Height = 48,
        Symbol = Symbol.UnSyncFolder
    });
    stackPanel.Children.Add(new TextBlock
    {
        Margin = new Thickness(12, 0, 0, 0),
        VerticalAlignment = VerticalAlignment.Center,
        Text = "UnSync Folder"
    });
    var button = new HamburgerButtonInfo
    {
        Content = stackPanel,
        ButtonType = HamburgerButtonInfo.ButtonTypes.Toggle,
        ClearHistory = false,
        PageType = typeof(Views.DetailPage)
    };
    MyHamburgerMenu.PrimaryButtons.Add(button);
