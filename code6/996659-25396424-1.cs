    private void texture_click (object sender, MouseButtonEventArgs e)
    {
        var image = sender as Image;
        if (image != null)
        {
            var border = image.Tag as Border;
            if (border != null)
            {
                border.Visibility = Visibility.Visible;
            }
            // ...
        }
    }
