    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        var listViewItem = new ListViewItem { Name= "Vanilla", Index = 1 };
        listView.Items.Add(listViewItem);
    }
