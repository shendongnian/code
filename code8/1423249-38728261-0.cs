    public async void Drop(IDropInfo dropInfo)
    {
      MainViewModel.Current.ShowBusyDialog();
      // First, copy the data out of the UI objects.
      List<SomeObject> list;
      var data = dropInfo.Data as SomeObject;
      var collection = (ObservableCollection<SomeObject>)
                                   ((ICollectionView) dropInfo.TargetCollection).SourceCollection;
      if (collection != null)
      {
        list = collection.ToList();
      }
      else if (dropInfo.Data is IEnumerable<SomeObject>)
      {
        list = ((IEnumerable<SomeObject>)dropInfo.Data).ToList();
      }
      // Then do the background work.
      await Task.Run(() =>
      {
        // Operate with `list`
      });
      // Finally, update the UI objects after the work is complete.
      MainViewModel.Current.CloseDialog();
    }
