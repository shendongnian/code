    // we're in the UI thread here
    PleaseWait = true; // indicate to the user we'll be back soon
    var whatever = GetStuffFromTheUIThatWeNeedInTheOtherThreadLol();
    Task.Run(() => 
    {
        // here we're on a background thread
        var result = OurLongRunningOperation(whatever);
        Application.Current.Dispatcher.BeginInvoke(
        DispatcherPriority.Normal, new Action(() =>
        {
            // we're back on the UI thread here
            UpdateUIWithResultsOfLongTimeOperationDerp(result);
            PleaseWait = false;
        }));
    });
    // snip
