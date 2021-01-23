    var sequences = items
        .SelectWithPreviousResult(
            new { Item = -1, GroupNumber = 0 }, // default result (used for first item)
            (item, previous) => new
            {
                Item = item,
                GroupNumber = previous.Item == x
                    ? previous.GroupNumber
                    : previous.GroupNumber + 1 })
        .GroupBy(x => x.GroupNumber, x => x.Item);
