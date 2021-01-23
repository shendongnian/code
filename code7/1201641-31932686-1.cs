    var joined = Observable.Merge(   // Convert the two sources into half-filled aggregates and merge them
            source1.Select(a => new Aggregate() { AlertData = a }),
            source2.Select(s => new Aggregate() { SoundRequestData = s }))
        .GroupBy(a => a.Id)
        // We only need two for each Id
        .Select(group => group.Take(2))  
        // This looks ugly, but is just joining the two messages into one
        .Select(group => group.Aggregate(new Aggregate(), (agg, newData) => new Aggregate() { AlertData = agg.AlertData ?? newData.AlertData, SoundRequestData = agg.SoundRequestData ?? newData.SoundRequestData }))
        // Back to one stream
        .Merge();
