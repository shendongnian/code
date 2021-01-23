    public List<Category> AllAnnouncements
    {
        get
        {
            using (var db = new YourDbContext())
            {
                var results = from a in db.Announcements select a;
                return results.ToList();
            }
        }
    }
