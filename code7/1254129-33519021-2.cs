    var endlessPickersPool = pickersPool.Cast<DictionaryEntry>().RepeatEndless();
    IEnumerator<DictionaryEntry> endlessEnumerator;
    IEnumerator<string> ptmKeyEnumerator;
    using ((endlessEnumerator = endlessPickersPool.GetEnumerator()) as IDisposable)
    using ((ptmKeyEnumerator = pickersToTicketMap.Keys.Cast<string>().ToList().GetEnumerator()) as IDisposable)
    {
        while (endlessEnumerator.MoveNext() && ptmKeyEnumerator.MoveNext())
        {
            DictionaryEntry pickersPoolItem = (DictionaryEntry)endlessEnumerator.Current;
            pickersToTicketMap[ptmKeyEnumerator.Current] = pickersPoolItem.Value;
        }
    }
