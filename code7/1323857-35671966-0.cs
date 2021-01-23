    await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
    {
        foreach (Source source in sources)
        {
            PivotItem pivotItem = new PivotItem(); /* At this point it falls. */
            pivotItem.Header = source.Name;
            pivotItem.Margin = new Thickness(0, -10, 0, 0);
            ListView listView = new ListView();
            listView.ItemsSource = source.Articles;
            listView.ItemTemplate = (DataTemplate)Resources["MainItemTemplate"];
            listView.ItemClick += OpenArticle_ItemClick;
            listView.SelectionMode = ListViewSelectionMode.None;
            listView.IsItemClickEnabled = true;
            pivotItem.Content = listView;
            pvtMain.Items.Add(pivotItem);
        }
    });
