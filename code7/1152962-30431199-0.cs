    private void loadButton_Click(object sender, RoutedEventArgs e)
    {
        var richWindow = RichTextWindow.GetWindow(new RichTextWindow());
        richWindow.Closed += (s, e) => loadButton.IsEnabled = true;
        loadButton.IsEnabled = false;
        richWindow.Show();
    }
