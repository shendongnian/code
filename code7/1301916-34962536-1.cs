    Then instead of db.Entry(company).State = EntityState.Modified; you
    could use a generic method to get your company data by a single
    primary key(for example companyId) like:
      
    
        public TEntity Get(string id) where TEntity : class
            {
                return _session.Get<TEntity>(id);
            }
    
    once you'll have the data from your database, you'll just update the
    values you want. Implementing IRepository pattern might be a little
    bit of an overkill, but it's a good pattern to know and it's good
    practice.
