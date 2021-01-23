    db.Entry(after).Property(x => x.Password).IsModified = false;
    db.Entry(after).Property(x => x.UrlIPath).IsModified = false;
    db.Entry(after).Property(x => x.TimeDate).IsModified = false;
    db.Entry(after).Property(x => x.TotalBalance).IsModified = false;
    db.Entry(after).Property(x => x.Verified).IsModified = false;
