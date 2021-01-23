    using System;
    using System.Reactive.Linq;
    using System.Threading;
    public MainWindow()
    {
        InitializeComponent();
        Observable.Timer(TimeSpan.Zero, TimeSpan.FromSeconds(1))
                  .ObserveOn(SynchronizationContext.Current)
                  .Subscribe(x => Label.Content = DateTime.Now.ToLongTimeString());
    }
