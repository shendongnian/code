    from a in ctx.As
    join b in ctx.Bs on a.AId equals b.AId into bs
    from b in bs.DefaultIfEmpty()
    join c in ctx.Cs on b.BId equals c.BId into cs
    from c in cs.DefaultIfEmpty()
    select new
    {
        a.AId,
        b.BId,
        c.CId
    }
