    static IEnumerable<Tuple<DateTime, DateTime, int>> 
           GetLocalMaximums(this IEnumerable<Tuple<DateTime, DateTime>> ranges)
    {
        DateTime lastStart = DateTime.MinValue;
        var queue = new List<DateTime>();
        foreach (var r in ranges)
        {
            queue.Add(r.Item2);
            var t = queue.Min();
            if (t < r.Item1)
            {
                yield return Tuple.Create(lastStart, t, queue.Count-1);
                do
                {
                    queue.Remove(t);
                    t = queue.Min();
                } while (t < r.Item1);
             }
             if (t == r.Item1) queue.Remove(t);
             else lastStart = r.Item1;
        }
        
        // yield the last local maximum
        if (queue.Count > 0)
            yield return Tuple.Create(lastStart, queue.Min(), queue.Count);
    }
