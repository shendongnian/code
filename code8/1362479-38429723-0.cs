    var result = data.GroupBy(item => new { item.OriginalDocumentNumber, item.FilterRound })
        .OrderBy(@group => @group.First().p2_FinalGrade)
        .AsEnumerable()
        .Select((@group, groupIndex) => new
        {
            Items = @group.Select((item, index) => new { Item = item, Index = ++index }),
            Rank = ++groupIndex
        })
        .SelectMany(v => v.Items, (s, i) => new
        {
            Data = i.Item,
            RankInGroup = i.Index,
            DenseRank = s.Rank
        }).ToList();
    
    result.Where(item => item.Data.p2_FinalGrade == "d" ||
                            item.Data.p2_FinalGrade == "f")
          .Where(item => item.Data.OriginalDocumentNumber == "590200054")....
