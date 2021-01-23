        public void AddCategory(string name)
        {
            Category category;
            using (var dbContext = new MyDbContext())
                category = dbContext.Categories.SingleOrDefault(x => x.Name == name);
            using (var dbContext = new MyDbContext())
            {
                if (category == null)
                    category = new Category(name, dbContext);
                else
                    dbContext.Categories.Attach(category);
                var movie = dbContext.Movies.Single(x => x.Id == Id);
                movie.Categories.Add(category);
                dbContext.SaveChanges();
            }
        }
