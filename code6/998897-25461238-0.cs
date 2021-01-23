    private void image1_Tap(object sender, GestureEventArgs e)
    {
        Image image = sender as Image;
        ContextMenu contextMenu = ContextMenuService.GetContextMenu(image);
        if (contextMenu.Parent == null)
        {
            contextMenu.IsOpen = true;
        }
    }
