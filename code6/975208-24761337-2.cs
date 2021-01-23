    var o = new ObservableCollection<long>();
    var s1 = Observable.Interval(TimeSpan.FromMilliseconds(100)).Subscribe(o.Add);
    var s2 =
        Observable.FromEventPattern<NotifyCollectionChangedEventArgs>(o, "CollectionChanged")
            .Buffer(TimeSpan.FromMilliseconds(500))
            .Subscribe(
                s =>
                {
                    Console.WriteLine("Last received {0}. Current count: {1}", Convert.ToInt64(s.Last().EventArgs.NewItems[0]), o.Count);                            
                });
