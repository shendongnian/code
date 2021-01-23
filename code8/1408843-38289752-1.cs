    using (var db = new PlaceDBContext())
    {
        Company c = db.Companies.Single(x => x.ID == 1);
        SearchKeyword sk = db.SearchKeywords.Single(x => x.ID == 1);
        c.SearchKeywords = new List<SearchKeyword>();
        c.SearchKeywords.Add(sk);
        db.SaveChanges();
    }
