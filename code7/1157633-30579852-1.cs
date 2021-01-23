    return inputs.Select(i => new AccountViewModel(i))
        .ToObservable()
        .ObserveOn(RxApp.MainThreadScheduler)
        .ToList()
        .Do(l =>
        {
            using (Accounts.SuppressChangeNotifications())
            {
                Accounts.AddRange(l);
            }
        })
        .SelectMany(x => x)
        .Select(x => Observable.DeferAsync(async _ =>
        {
            var res = await x.ProcessAsync(config, m, outputPath);
            processed++;
            var prog = ((double) processed/inputs.Count())*100.0;
            OverallProgress.Message.OnNext(string.Format("Processing Accounts ({0:000}%)", prog));
            OverallProgress.Progress.OnNext(prog);
            return Observable.Return(res);
        }))
        .Merge(5)
        .All(x => x);
