    private void texture_click (object sender, MouseButtonEventArgs e)
    {
        //tile_border.Visibility = Visibility.Visible;
        var image = sender as Image;
        if (image != null)
        {
            current_tilefile = image.Source;
            string source_string = image.Source.ToString();
            int last_slash = source_string.LastIndexOf ('/');
            current_tile = source_string.Substring (last_slash + 1, 3);
        }
    }
