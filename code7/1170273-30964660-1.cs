    Func<IEnumerable<TextBox>, IObservable<int>> makeTextBoxCounter = tbs =>
        tbs
            .Select(tb =>
                Observable
                    .FromEventPattern(h => tb.TextChanged += h, h => tb.TextChanged -= h))
            .Merge()
            .Select(ep =>
            {
                var total = 0;
                foreach (var tb2 in tbs)
                {
                    var value = 0;
                    if (int.TryParse(tb2.Text, out value))
                    {
                        total += value;
                    }
                }
                return total;
            });
