    public static Task<TResult[]> ExecuteInParallel<T, TResult>(this IList<T> source, int degreeOfParalleslism, Func<T, Task<TResult>> body)
    {
        var lists = await Task.WhenAll<List<TResult>>(
            Partitioner.Create(source).GetPartitions(degreeOfParalleslism)
                .Select(partition => Task.Run<List<TResult>>(async () =>
                        {
                            var list = new List<TResult>();
                            using (partition)
                            {
                                while (partition.MoveNext())
                                {
                                    results.Add(await body(partition.Current));
                                }
                            }
                            return list;
                       }));
         return lists.SelectMany(list => list).ToArray();
    }
