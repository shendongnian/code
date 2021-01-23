    using (MsSqlDataContext db = new MsSqlDataContext())
    {
        DataLoadOptions options = new DataLoadOptions();
        options.LoadWith<PromoCode>(p => p.CustomerPromos);
        db.LoadOptions = options;
        return db.PromoCodes.ToArray();
    }
