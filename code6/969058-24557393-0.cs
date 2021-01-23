    var model = entity.AsEnumerable()
                      .Select(e => new SummaryViewModel
    {
        Address = e.Address.ToOneLine(), Id = e.Id
    }).ToList();
