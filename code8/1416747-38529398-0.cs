    private void Viewbox_SizeChanged(object sender, SizeChangedEventArgs e)
    {
        double initialWidth = 509.0;
        if (e.PreviousSize.Width > 0)
        {
            var factor = e.NewSize.Width / initialWidth;
            this.Title = (factor * 100).ToString();
        }
    }
