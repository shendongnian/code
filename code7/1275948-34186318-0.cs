    private void grid_SizeChanged(object sender, SizeChangedEventArgs e)
    {
        //text.Text = grid.Width.ToString();
        Dispatcher.BeginInvoke(new Action(() => text.Text = grid.Width.ToString()));
    }
