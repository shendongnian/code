    public static class Extensions
    {
        public static IEnumerable<IEnumerable<int>> ContinuousNumbers(this IEnumerable<int> source)
        {
            using (var e = source.GetEnumerator())
            {
                if (e.MoveNext())
                {
                    var list = new List<int> { e.Current};
                    int temp = e.Current;
                    while (e.MoveNext())
                    {
                        if (e.Current == temp+1)
                        {
                            list.Add(e.Current);
                            temp++;
                        }
                        else
                        {
                            yield return list;
                            list = new List<int> { e.Current};
                            temp = e.Current;
                        }
                    }
                   
                    if (list.Count > 0)
                    {
                        yield return list;
                    }
                }
            }
        }
    }
