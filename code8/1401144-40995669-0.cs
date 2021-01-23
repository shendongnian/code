    using (var _dbContext = new DbContext())
    {
        var sale = _dbcontext.Sale
            .Single(s => s.Id == 1);
       context.Entry(sale)
            .Collection(n => n.SalesNotes)
            .Load();
      
       context.Entry(sale)
            .Reference(u => u.User)
            .Load();
    }
