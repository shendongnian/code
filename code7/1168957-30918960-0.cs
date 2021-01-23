    [ChildActionOnly]
    public PartialViewResult SomePartial()
    {
        var vm = _ctx.Something.Select(p => new HistoricalDataVM()
        {
                SomeDate = DateTime.ParseExact(p.SomeDate, "MM/dd/yyyy", CultureInfo.InvariantCulture),
                SomeOtherDate = DateTime.ParseExact(p.SomeOtherDate, "MM/dd/yyyy", CultureInfo.InvariantCulture),
                ....
            }).OrderByDescending(c => c.SomeDate).ToList();
            return PartialView(vm);
        }
