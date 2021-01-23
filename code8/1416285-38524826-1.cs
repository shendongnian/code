    private void MainPage_Loaded(object sender, RoutedEventArgs e)
    {
        foreach (var item in DownloadTaskListView.Items)
        {
            var listviewitem = item as DownloadTask;
            var container = DownloadTaskListView.ContainerFromItem(listviewitem) as ListViewItem;
            var ItemViewGrid = container.ContentTemplateRoot as Grid;
            //TODO:
        }
    }
