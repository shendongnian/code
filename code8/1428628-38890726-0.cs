    var college = await Task.Run(() => DataSource.getCollege((string)e.Parameter);
    await CoreApplication.MainView.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, async () =>
        {
        coll_grid.DataContext = college;
     });
