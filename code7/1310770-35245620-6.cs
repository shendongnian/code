    new string[] { "a,b", "c,d,e" }.ToObservable()
        .Select(str => str.Split(',')
            .ToObservable()
            .Select(x => Observable.Timer(DateTime.Now.AddSeconds(2))
                    .Select(_ => x.ToUpper())).Concat()
            .ToArray()).Concat()
            .Subscribe();
