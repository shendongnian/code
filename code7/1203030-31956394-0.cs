    public static class Foo
    {
        public static IObservable<double> GetAverageOfLatest(this IEnumerable<IObservable<double>> sources)
        {
            int count = 1;
            var sums = sources.Aggregate(
                (left, right) =>
                    {
                        //count how many satellites you have.
                        count ++;
                        return Observable.CombineLatest(left, right, (l, r) => l + r);
                    });
            return sums.Select(sum => sum / count);
        }
    }
