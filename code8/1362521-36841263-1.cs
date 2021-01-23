    public static class GroupType
    {
        public static IEnumerable<Type2> GroupByRuns(this IEnumerable<Type1> sequence)
        {
            if (sequence.Count() == 0)
                yield break;
            List<bool> next_items = sequence.Select(s => s.isbool).ToList();
            next_items.Add(false);
            bool previous_item = false;
            int idx = 1;
            foreach (var item in sequence)
            {
                if (item.isbool)
                {
                    if (previous_item == false)
                    {
                        yield return new Type2 { Tuple = Type2.TupletType.Start };
                    }
                    else if (next_items.ElementAt(idx) == true)
                    {
                        yield return new Type2 { Tuple = Type2.TupletType.None };
                    }
                    else
                    {
                        yield return new Type2 { Tuple = Type2.TupletType.Stop };
                    }
                }
                else
                {
                    yield return new Type2 { Tuple = Type2.TupletType.None };
                }
                previous_item = item.isbool;
                idx++;
            }
        }
    }
