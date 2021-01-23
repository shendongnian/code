        IEnumerable<int> values =  pickersPool.Values.Cast<int>();
        if (pickersPool.Count < pickersToTicketMap.Count)
        {
            // Repeat this collection until it has the same size as the larger collection
            values = Enumerable.Repeat( values,
                pickersToTicketMap.Count / pickersPool.Count
                  + pickersToTicketMap.Count % pickersPool.Count
            )
            .SelectMany(intColl => intColl);
        }
        List<int> valueList = values.ToList();
        for (int i = 0; i < valueList.Count; i++)
            pickersToTicketMap[i] = valueList[i];
