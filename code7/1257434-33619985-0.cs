    public Person GetPerson(params Expression<Func<Person, object>>[] includes)
    {
        using (var db = new DbContext())
        {
            IQueryable<Person> query = db.Posts;
            Array.ForEach(includes, expression => query = query.Include(expression));
            return query.FirstOrDefault();
        }
    }
