    private void Image_MouseDown(object sender, MouseButtonEventArgs e)
    {
        if (e.ChangedButton == MouseButton.Left)
        {
           e.Handled = true;
           Image image = sender as Image;
           ContextMenu contextMenu = image.ContextMenu;
           contextMenu.PlacementTarget = image;
           contextMenu.IsOpen = true;
        }
    }
