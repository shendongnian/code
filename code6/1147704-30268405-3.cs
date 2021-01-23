    private void mouse_Enter(object sender, PointerRoutedEventArgs e)
    {
        hoverBrush.Color = Color.FromArgb(140, 40, 40);
        hoverBrush.Opacity = 1;
        nsfwEllipse.Fill = hoverBrush;
    }
    private void mouse_Exit(object sender, PointerRoutedEventArgs e)
    {
        hoverBrush.Color = Color.FromArgb(180, 60, 60);
        hoverBrush.Opacity = 1;
        nsfwEllipse.Fill = hoverBrush;
    }
