        public void Update(game g)
        {
            db.Entry(g).State = EntityState.Modified; 
            Save();           
        }
        public void Save()
        {
            db.SaveChanges();
        }
