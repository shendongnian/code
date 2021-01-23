    <Image x:Key="CopyImage1" Source="../Images/copy.png"/>
    <Image x:Key="CopyImage2" Source="../Images/copy.png"/>
    <Image x:Key="CopyImage3" Source="../Images/copy.png"/>
    <Image x:Key="CopyImage4" Source="../Images/copy.png"/>
    
    var contextMenu = new ContextMenu();
        contextMenu.Items.Add(new MenuItem { Header = "Copy All", Icon  = FindResource("CopyImage1") });
        contextMenu.Items.Add(new MenuItem { Header = "Copy All with Headers", Icon = FindResource("CopyImage2") });
        contextMenu.Items.Add(new MenuItem { Header = "Copy Selected", Icon = FindResource("CopyImage3") });
        contextMenu.Items.Add(new MenuItem { Header = "Copy Selected with Headers", Icon = FindResource("CopyImage4") });
