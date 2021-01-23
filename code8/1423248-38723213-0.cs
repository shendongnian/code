    public async void Drop(IDropInfo dropInfo)
    {
        // We are in the UI thread here!
        MainViewModel.Current.ShowBusyDialog();
        // as we are on the UI thread, no worries touching the collection here
        var collection = (ObservableCollection<SomeObject>)
             ((ICollectionView)dropInfo.TargetCollection).SourceCollection;
        // as we are on the UI thread, this is the UI dispatcher.
        var dispatcher = Dispatcher.CurrentDispatcher;
        await Task.Run(() =>
        {
            // We are on a background thread here!
            var data = dropInfo.Data as SomeObject;
            YourResults results = null;
            if (data != null)
            {
                results = WhateverProcessingTakesALongTime();
            }
            else if (dropInfo.Data is IEnumerable<SomeObject>)
            {
                results = SameHereIHaveNoIdea(dropInfo.Data);
            }
            // Now, let's update the UI on the UI thread.
            await dispatcher.InvokeAsync(() =>
            {
                UpdateStuffWithStuff(collection, results);
            });
        });
        MainViewModel.Current.CloseDialog();
    }
