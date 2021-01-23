    private TreeViewItem activeItem;
    public Window()
    {
        InitializeComponent();
        // sender is the TreeView itself. Just iterate through the items
        // and retrieve the first one where IsMouseOver returns true.
        TreeView.ContextMenuOpening += (sender, e) =>
        {
            activeItem = ((TreeView) sender).Items.OfType<TreeViewItem>().FirstOrDefault(item => item.IsMouseOver);
        };
        TreeView.ContextMenuClosing += (o, e) =>
        {
            activeItem = null;
        };
    }
    private void addRom_Click(object sender, RoutedEventArgs e) 
    {
        // Once we get here, activeItem will reference the TreeViewItem
        // that was under the cursor when the context menu was opened.
        AddRoomsDialog roomsDialog = new AddRoomsDialog(activeItem);
        roomsDialog.Show();
    }
