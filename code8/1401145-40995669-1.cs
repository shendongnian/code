    using (var _dbContext = new DbContext())
    {
        var sale = _dbcontext.Sale
            .Single(s => s.Id == 1);
       _dbcontext.Entry(sale)
            .Collection(n => n.SalesNotes)
            .Load();
      
       _dbcontext.Entry(sale)
            .Reference(u => u.User)
            .Load();
    }
