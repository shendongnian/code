    private void ImageButtonClicked(object sender, RoutedEventArgs args)
    {
        ImageWindow imageWindow = new ImageWindow();
        Button btn = args.OriginalSource as Button;
        imageWindow.Content = btn.Content;
        imageWindow.Show();
    }
