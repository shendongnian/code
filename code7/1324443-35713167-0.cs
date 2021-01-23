        static IEnumerable<DateTimeInterval> GetIntersections(IEnumerable<DateTimeInterval>[] personsAvailableSlots)
        {
            var enumerators = personsAvailableSlots.Select(timeline => timeline.GetEnumerator()).ToArray();
            // Intersection is empty when at least one of iterators is empty.
            for (int i = 0; i < personsAvailableSlots.Length; i++) if (!enumerators[i].MoveNext()) yield break;
            while (true)
            {
                // first we ensure that intersection exists at the current state
                // if not so, we have to move some iterators forward
                var start = enumerators.Select(tl => tl.Current).Max(interval => interval.Start);
                foreach (var iter in enumerators)
                    while (iter.Current.Start + iter.Current.Length <= start)
                        if (!iter.MoveNext()) yield break;
                // now we check if the interval exists
                var int_start = enumerators.Select(tl => tl.Current).Max(interval => interval.Start);
                var int_end = enumerators.Select(tl => tl.Current).Min(interval => interval.Start + interval.Length);
                if (int_end > int_start)
                {
                    //if so, we return it
                    yield return new DateTimeInterval()
                    {
                        Start = int_start,
                        Length = int_end - int_start
                    };
                    // and, finally, we ensure next interval to start after the current one ends
                    //
                    // CAUTION: We are able to move iterators whose current interval have passed only. 
                    // We will miss huge spans which cover several intervals in other iterators otherwise.
                    //
                    // In fact we should move the only inerator - that one wich currently limits the last result
                    foreach (var iter in enumerators)
                        while (iter.Current.Start + iter.Current.Length == int_end)
                            if (!iter.MoveNext()) yield break;
                } 
            }
        }
