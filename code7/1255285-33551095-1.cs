        var hashSet = new HashSet<Tuple<int,int>>();
        foreach (var item in pairs)
        {
            var tuple = new Tuple<int,int>();
            if (item.Book1.Id < item.Book2.Id)
            {
                tuple.Item1 = item.Book1.Id;
                tuple.Item2 = item.Book2.Id;
            }
            else
            {
                tuple.Item1 = item.Book2.Id;
                tuple.Item2 = item.Book1.Id;
            }
            if (hashSet.Contains(tuple))
            {
                tempList.Remove(dup);
            }
            else
            {
                hashSet.Add(tuple);
            }
        }
