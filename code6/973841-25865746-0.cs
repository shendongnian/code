    List<string> result = new List<string>();
    using (var enumerator1 = list1.GetEnumerator())
    using (var enumerator2 = list2.GetEnumerator())
    {
        int countBefore;
        do
        {
            countBefore = result.Count;
            if (enumerator1.MoveNext())
                result.Add(enumerator1.Current);
            if (enumerator2.MoveNext())
                result.Add(enumerator2.Current);
        } while (countBefore < result.Count);
    }
