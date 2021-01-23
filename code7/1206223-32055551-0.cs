    var contextMenu = new ContextMenu();
    contextMenu.Items.Add(new MenuItem
    {
    	Header = "Copy All",
    	Icon = new Image {Source = FindResource("CopyImageSource") as ImageSource}
    });
    contextMenu.Items.Add(new MenuItem
    {
    	Header = "Copy All with Headers",
    	Icon = new Image {Source = FindResource("CopyImageSource") as ImageSource}
    });
    contextMenu.Items.Add(new MenuItem
    {
    	Header = "Copy Selected",
    	Icon = new Image {Source = FindResource("CopyImageSource") as ImageSource}
    });
    contextMenu.Items.Add(new MenuItem
    {
    	Header = "Copy Selected with Headers",
    	Icon = new Image {Source = FindResource("CopyImageSource") as ImageSource}
    });
