    private void Image_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
    {
         Image image = sender as Image;
         ContextMenu contextMenu = image.ContextMenu;
         contextMenu.PlacementTarget = image;
         contextMenu.IsOpen = true;         
    }
