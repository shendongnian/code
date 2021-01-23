       Observable.FromEventPattern<CollectionChangeEventArgs>(temp2, "CollectionChanged")
                 .Buffer(new TimeSpan(1000))
                 .Where(x => x.Any())
                 .Select(x => i.Sender)
                 .Subscribe(UpdateItems);
