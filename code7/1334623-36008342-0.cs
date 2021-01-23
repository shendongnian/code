    var result = List
        .GroupBy(s => new { s.Id, s.Name })
        .Select(xGrp => new Target
        {
            Id = xGrp.Key.Id,
            Name = xGrp.Key.Name,
            Members = xGrp
                .Select(s => new Member 
                { 
                    Id = s.MemberId, 
                    Name = s.MemberName
                })
                .ToList()
        })
        .ToList();
