    using (var ctx = new MyContext())
    {
        ctx.Parents.Attach(parent);
        ctx.Entry(parent).State = EntityState.Added;  // or EntityState.Modified
        ctx.SaveChanges();
    }
