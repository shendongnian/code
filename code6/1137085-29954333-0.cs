    var notesEnu = dataAccess.GetList<Note>(pn => pn.ProjectVersionID == projectVersionID, filterExtensions.ToArray())
                  .AsEnumerable();
    foreach (var filter in filters)
    {
        notesEmu = notesEmu.Where(filter);
    }
    notes = notesEnu.Take(10).ToList();
