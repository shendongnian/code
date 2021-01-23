    CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(SomeListView.ItemsSource);
    using (view.DeferRefresh())
    {
      view.GroupDescriptions.Clear();
      view.GroupDescriptions.Add(new PropertyGroupDescription("Country"));
      view.GroupDescriptions.Add(new PropertyGroupDescription("Active"));
    }
