    var group =
    from c in d.Car
    group c by new
    {
        c.Color,
        c.Price,
    } into gcs
    select new Cars()
    {
      Car =  gcs.ToList()
    };
