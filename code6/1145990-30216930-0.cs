    public Business GetBusinessForUser(string userId)
    {
        using (var db = new MyContext(_connectionString))
        {
            var q =
                   (from b in db.Businesses
                   join bm in db.BusinessMembers on b.ID equals bm.ID_Business
                   where bm.UserId == userId
                   select b).Include(business => business.BusinessStatus);
            return q.FirstOrDefault();
        }
    }
