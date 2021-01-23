    .Join(
        Context.Query<ProgramProductView>(),
        e => new {e.ItemId, e.TypeId},
        prog => new {ItemId = prog.Id, prog.TypeId},
        (e, prog) =>
            new
            {
                ...
                (DateTime?)prog.StartDate,
                ...
             }).OrderBy(d => d.PurchaseDate);
