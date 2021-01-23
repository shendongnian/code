    var ranked = participants
        .OrderByDescending(p => p.Score1)
        .ThenByDescending(p => p.Score2)
        .Select((p, i) => new { Order = 1 + i, Participant = p })
        .GroupBy(p => new { p.Participant.Score1, p.Participant.Score2 })
        .SelectMany(g => g.Select(p => new {
            Id = p.Participant.Id,
            Rank = g.Min(x => x.Order),
            ExpectedRank = p.Participant.ExpectedRank
        }));
    foreach (var p in ranked)
        Console.WriteLine(p);
