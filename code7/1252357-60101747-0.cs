        MyDbContext db = new MyDbContext();
        public async Task<IList<MyDbSet>> GetEntities(filter f)
        {
            using (db)
            { 
                var query = null;
                if (f != null && f.field.Any())
                {
                    query = db.MyDbSet.AsQueryable().Where((a, index) => a == f);
                }
                return await query.ToListAsync();
            }
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
