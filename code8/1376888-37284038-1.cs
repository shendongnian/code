    ComboBoxItem cbiSelected = null;
    private void cbDocket_MenuItemRemove(object sender, RoutedEventArgs e)
    {
        cbDocket.Items.Remove(cbiSelected);
    }
    private void cbDocket_OnMouseMove(object sender, MouseEventArgs e)
    {
        ComboBoxItem cbiHover = sender as ComboBoxItem;
        if (cbiHover.IsHighlighted)
        {//Verify the item is highlighted
            cbiSelected = cbiHover;
        }
    }
