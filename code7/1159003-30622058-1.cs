    var dict = result
        .GroupBy(o => new {o.SehirID, o.uniKodu})
        .ToDictionary(
            g => g.Key.uniKodu, 
            g => g.ToDictionary(
                r => r.SehirId, 
                r => g.Count(r.SehirId)
            )
        );
