    System.IDisposable whenActivatedSubscription = null;
    whenActivatedSubscription = this.WhenActivated(d =>
    {
        Debug.WriteLine("SubView activated.");
        d(Disposable.Create(() => { Debug.WriteLine("SubView deactivated."); }));
        d(this // ViewModel -> DataContext
            .WhenAnyValue(v => v.ViewModel)
            .BindTo(this, v => v.DataContext));
        d(whenActivatedSubscription); // <- Dispose of the activation subscription here
    });
