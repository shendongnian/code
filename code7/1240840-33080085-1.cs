    private void Image_MouseUp(object sender, MouseButtonEventArgs e)
    {
         if (e.ChangedButton == MouseButton.Left)
         {
             Image image = sender as Image;
             ContextMenu contextMenu = image.ContextMenu;
             contextMenu.PlacementTarget = image;
             contextMenu.IsOpen = true;
         }
    }
