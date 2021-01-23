    var original = db.TcSet.Find(tcSet.TcSetID);
    var sets = db.TcSet
        .Where(x => x.SetName.Equals(original.SetName, StringComparison.OrdinalIgnoreCase))
        .ToList();
    foreach (var set in sets)
    {
       set.ModifiedBy = User.Identity.Name;
       set.ModifiedOn = DateTime.Now;
       set.PhysicalUnit = tcSet.PhysicalUnit;
       db.Entry(set).State = EntityState.Modified;
       db.Entry(set).Property(x => x.CreatedBy).IsModified = false;
       db.Entry(set).Property(x => x.CreatedOn).IsModified = false;
       db.Entry(set).Property(x => x.TechnicalCharacteristicID).IsModified = false;
    }
