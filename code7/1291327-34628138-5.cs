    public List<Auction> GetAuctions()
    {
        using (DataContext db = new DataContext())
        {
            return db.Auctions.ToList();
        }
    }
