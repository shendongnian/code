    MyDto myDto = null;
    var result = Session.QueryOver<MyEntity>()
        .Where(x => x.State == State.Pending)
        .SelectList(list => list
            .Select(Projections.Distinct(Projections.Property<MyEntity>(x => x.Corporation)))
            .Select(x => x.CalculationDate)
            .Select(x => x.ValuationRule)
            )
        .ToList<object[]>()
        //.Select(x => new    // This is optional to use anonymus type instead a object[]
        //      {
        //         Corporation = (string) x[0],
        //         CalculationDate = (DateTime?) x[1],
        //         ValuationRule = (string) x[2]
        //      })
        //.List()
        ;
