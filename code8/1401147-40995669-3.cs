    using (var _dbContext = new DbContext())
    {
        var sale = _dbContext.Sale
            .Single(s => s.Id == 1);
        _dbContext.Entry(sale)
            .Collection(n => n.SalesNotes)
            .Load();
      
        _dbContext.Entry(sale)
            .Reference(u => u.User)
            .Load();
    }
