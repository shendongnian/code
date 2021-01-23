    var list = new List<int[]>();
    list.Add(new int[] { 1, 2, 3, 4 });
    list.Add(new int[] { 5, 4, 2, 1 });
    list.Add(new int[] { 5, 9, 3, 5 });
    var result = list.SelectMany(item => item.Select((innerItem, index) => new { index, innerItem }))
                        .GroupBy(item => item.index, (key, group) => group.Sum(item => item.innerItem))
                        .ToList();
