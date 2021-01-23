    List<int> data = new List<int> { 1, 2, 1, 2, 3, 1, 2, 3, 4, 1, 2, 3, 4, 5, 6 };
    int groupId = 0;
    var groups = data.Select
                     ( (item, index)
                       => new
                          { Item = item
                          , Group = index > 0 && item < data[index - 1] ? ++groupId : groupId
                          }
                     );
    List<List<int>> list = groups.GroupBy(g => g.Group)
                                 .Select(x => x.Select(y => y.Item).ToList())
                                 .ToList();
