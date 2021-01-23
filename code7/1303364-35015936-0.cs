    double[] items = { 1, 2, 3, 4, 5 };
    IEnumerable<Tuple<double, int>> results = items.Select(x =>
        {
            int index = 0;
            foreach (var condition in new Func<bool>[]
                {
                    // TODO: Write conditions here.
                    () => x == 1,
                    () => x == 2
                })
            {
                if (condition() == true)
                    return index;
                else
                    index++;
            }
            return -1;
        }).Zip(items, (matchedCondtion, item) => Tuple.Create(item, matchedCondtion))
        .Where(x => x.Item2 != -1);
