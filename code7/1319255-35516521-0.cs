    IEnumerable<int> GetMatchingSetIDs(SortedSet<int> userSet)
        {
            IEqualityComparer<SortedSet<int>> setComparer = SortedSet<int>.CreateSetComparer();
            foreach (Ticket ticket in tickets) //Where ticket is your ticket class with the sortedsets
            {
                if (setComparer.Equals(ticket.Set, userSet))
                {
                    yield return ticket.ID;
                }
            }
        }
