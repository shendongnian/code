    var sameDTNotes =
        (from an in activationNotesTmp
            join dn in desactivationNotesTmp on an.DropTimeParam equals dn.DropTimeParam
            select new { an.DropTimeParam, ActuatorParams = new[] { an.ActuatorParam, dn.ActuatorParam } });
    var result=sameDTNotes.GroupBy(p => p.DropTimeParam, p => p.ActuatorParams)
    .Select(p => new PlayingNote
    {
        DropTimeParam = p.Key,
        ActuatorParam = AndBynary(p.SelectMany(q => q))
    }).ToList();
