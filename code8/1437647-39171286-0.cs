    public void WriteLineWithEnum(string value, Severity severity)
    {
        base.WriteLine(value);
        listView.Items.Add(value.ToString());
        SolidColorBrush bgColorBrush = OutputBackgroundConverter.Convert(severity);
        (listView.Items.GetItemAt(listView.Items.Count - 1) as ListViewItem).Background = OutputBackgroundConverter.Convert(severity);
    }
        }
