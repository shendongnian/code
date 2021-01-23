        public ReceptDTO GetReceptForUser(string userId)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            { 
                var q = from r in db.Recipes where r.UserId == userId select new ReceptDTO
                    {
                         RecipeID = r.RecipeID,
                         Title = r.Title,
                         Portion = r.Portion,
                         Time = r.Time,
                         Category = r.Category,
                         Preparation = r.Preparation,
                         Difficulty = r.Difficulty,
                         Views = 0,
                         Price = r.Price,
                         Date = DateTime.Now,
                         UserId = userId
                    };
                return q.FirstOrDefault();
            }
        }
