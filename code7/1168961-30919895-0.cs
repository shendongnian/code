    private void LongText_TextChanged(object sender, TextChangedEventArgs e)
    {
        var textBox = sender as TextBox;
        var max = (textBox.ExtentHeight - textBox.ViewportHeight);
        var offset = textBox.VerticalOffset;
        if (max != 0 && max == offset)
            this.Dispatcher.BeginInvoke(new Action(() =>
                {
                    textBox.ScrollToEnd();
                }),
                System.Windows.Threading.DispatcherPriority.Loaded);
    }
