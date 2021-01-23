    using (var ctx = new MyDbContext())
    {
          //Delete Invoice
          ctx.SaveChanges();
    }
    using (var ctx = new MyDbContext())
    {
          //Delete related costs
          ctx.SaveChanges();
    }
