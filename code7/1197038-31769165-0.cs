    var sameDTNotes =
    (from an in activationNotesTmp
        join dn in desactivationNotesTmp on an.DropTimeParam equals
            dn.DropTimeParam into sameDt
        from s in sameDt
        .GroupBy(p => p.DropTimeParam, p => p.ActuatorParam)
        select new PlayingNote
        {
            DropTimeParam = an.DropTimeParam,
            ActuatorParam = AndBynary(s)
        }).ToList();
