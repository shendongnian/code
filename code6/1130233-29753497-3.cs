<!-- -->
    public List<Result> GetJoinResult(int languageId)
    {
        using (DatabaseDataContext db = new DatabaseDataContext())
        {
            return db.Products.Join(db.ProductDetails, p => p.ID, d => d.ProductID,
                (p, d) => new Result // not anonymous
                {
                    ID = p.ID,
                    Photo = p.Photo,
                    Name = d.Name,
                    LanguageID = d.LanguageID,
                })
                .Where(x => x.LanguageID == languageId)
                .ToList();
        }
    }
