    var dummy = context.Dummy.FirstOrDefault();
    var newSequence = context.TableA
        .Select(itemInTableA =>
            new
            {
                RowA = itemInTableA,
                Dummy = dummy,
            });
