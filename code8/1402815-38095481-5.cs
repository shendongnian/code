    public ICollection<PhotoFile> FindAllBy(params Expression<Func<PhotoFile, bool>>[] criteria)
    {
        using (var ctx = new CotanContext())
            return ctx.PhotoFiles.WhereAny(criteria).ToList();
    }
