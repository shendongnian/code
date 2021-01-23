    private void MyClickFunction(object sender, RoutedEventArgs e)
    {
        var tag = ((Button)sender).Tag;
        MessageBox.Show(tag.ToString());
    }
