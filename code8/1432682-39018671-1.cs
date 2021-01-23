    var ranking = arr.Select((item, index) => new { Item = item, Index = index })
                     .OrderByDescending(item => item.Item)
                     .Select((item, index) => new { Item = item.Item, OriginalIndex = item.Index, Rank = ++index })
                     .OrderBy(item => item.OriginalIndex)
                     .Select(item => item.Rank)
                     .ToList();
    //Output: 6, 2, 5, 2, 4, 1, 7
