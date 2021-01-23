    var contextMenu = new ContextMenu();
    contextMenu.Items.Add(new MenuItem { Header = "Copy All", Icon  = new BitmapImage(new Uri("images/copy.png", UriKind.Relative)) });
    contextMenu.Items.Add(new MenuItem { Header = "Copy All with Headers", Icon = new BitmapImage(new Uri("images/copy.png", UriKind.Relative)) });
    contextMenu.Items.Add(new MenuItem { Header = "Copy Selected", Icon = new BitmapImage(new Uri("images/copy.png", UriKind.Relative)) });
    contextMenu.Items.Add(new MenuItem { Header = "Copy Selected with Headers", Icon = new BitmapImage(new Uri("images/copy.png", UriKind.Relative)) });
