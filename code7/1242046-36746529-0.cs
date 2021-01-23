    foreach (var a in ttTableA.Where(r => r.RowMod == "U"))
    {
        foreach (var b in (
            from row in Db.TableB.With(LockHint.UpdLock)
            where row.Company == Session.CompanyID
            select row).ToList())
        {
            b.Field1 = a.Field1;
        }
    }
