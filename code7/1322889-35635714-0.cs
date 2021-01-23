    public static IEnumerable<RangePeriod> Minus(
        this IEnumerable<RangePeriod> first,
        IEnumerable<RangePeriod> second)
    {
        // First make sure that the lists are ordered by their start dates.
        var firstSorted = first.OrderBy(r => r.StartDate);
        var secondSorted = second.OrderBy(r => r.StartDate);
        // get the enumerators of the sorted sequences.
        using (var keep = firstSorted.GetEnumerator())
        using (var remove = secondSorted.GetEnumerator())
        {
            // if there are no ranges to keep then return an empy sequence.
            if (!keep.MoveNext()) yield break;
            var currentKeep = keep.Current;
            RangePeriod currentRemove = null;
            if (remove.MoveNext()) currentRemove = remove.Current;
            while (true)
            {
                // if there are no more remove ranges or the remove range is after the keep
                // then just yield the keep range and move to the next keep range.
                if (currentRemove == null || currentKeep.EndDate < currentRemove.StartDate)
                {
                    yield return currentKeep;
                    if (!keep.MoveNext()) yield break;
                    currentKeep = keep.Current;
                    continue;
                }
                // if the remove range is before the keep then move to the next remove range.
                if (currentRemove.EndDate < currentKeep.StartDate)
                {
                    currentRemove = remove.MoveNext() ? remove.Current : null;
                    continue;
                }
                // if the remove range ends before the keep range
                if (currentRemove.EndDate < currentKeep.EndDate)
                {
                    // if the keep starts before the remove then we yield a range from the keep's start
                    // to the remove's start - 1 day.
                    if (currentKeep.StartDate < currentRemove.StartDate)
                    {
                        yield return new RangePeriod(currentKeep.StartDate, currentRemove.StartDate.AddDays(-1));
                    }
                    // change the keep's start to the remove's end + 1 and move to the next remove range.
                    currentKeep = new RangePeriod(currentRemove.EndDate.AddDays(1), currentKeep.EndDate);
                    currentRemove = remove.MoveNext() ? remove.Current : null;
                    continue;
                }
                // if the remove range completely covers the keep then move to the next keep (if there is one)
                if (currentRemove.StartDate < currentKeep.StartDate)
                {
                    if (!keep.MoveNext()) yield break;
                    currentKeep = keep.Current;
                    continue;
                }
                // Otherwise the remove range starts after the keep starts but before the keep ends and the
                // remove ends after the keep ends, so we need to yield a range that starts on the keep's
                // start and ends before the remove's start and move to the next keep range.
                yield return new RangePeriod(currentKeep.StartDate, currentRemove.StartDate.AddDays(-1));
                if (!keep.MoveNext()) yield break;
                currentKeep = keep.Current;
            }
        }
    }
