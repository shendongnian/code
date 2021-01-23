    private void Tap_N(object sender, System.EventArgs e)
    {
        var path = (Path)sender;
        var fill = (SolidColorBrush)path.Fill;
        if (fill.Color == Colors.White)
        {
            fill.Color = Colors.Transparent;
        }
        else
        {
            fill.Color = Colors.White;
        }
    }
