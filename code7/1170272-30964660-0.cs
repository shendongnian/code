    Func<IEnumerable<CheckBox>, IObservable<int>> makeCheckBoxCounter = cbs =>
        cbs
            .Select(cb => Observable.FromEventPattern(h => cb.Click += h, h => cb.Click -= h))
            .Merge()
            .Select(ep => cbs.Where(cb2 => cb2.Checked == true).Count());
