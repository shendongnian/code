    var result = transactions
        .GroupBy(t => new { t.Year, t.Refno, t.SetaCode })
        .Select(grp => new
        {
            Year = grp.Key.Year,
            Refno = grp.Key.Refno,
            SetaCode = grp.Key.SetaCode,
            TotalCollected = grp.Sum(x => x.TotalCollected)
        })
        .Where(r => r.TotalCollected < -100000)
        .OrderBy(r => r.Year).ThenBy(r => r.Refno).ThenBy(r => r.SetaCode)
        .ToList();
