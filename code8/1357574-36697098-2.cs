    using (var db = new context())
    {
      var query = db.Orders
        .Include(o=>o.Events)
        .Include(o=>o.Events.Select(e=>e.Groups))
        .Select(o=>new Order
        {
          Id=o.Id,
          Events = o.Events.Where(e => e.SomeBool && e.SomeBool2).ToList()
        });
    }
