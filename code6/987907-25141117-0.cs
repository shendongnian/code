    private void selected(object sender, MouseButtonEventArgs e)
    {
        Image newimage = new Image();
        newimage.Source = ((Image)sender).Source;
    }
