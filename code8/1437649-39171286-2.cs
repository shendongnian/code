    public void WriteLineWithEnum(string value, Severity severity)
    {
        ListViewItem item = new ListViewItem();
            item.Content = value.ToString();
            SolidColorBrush bgColorBrush = OutputBackgroundConverter.Convert(severity);
            item.Background = bgColorBrush;
            myListView.Items.Add(item);
    }
