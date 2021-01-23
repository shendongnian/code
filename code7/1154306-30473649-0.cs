    (from t in db.Teapots.Include(t => t.Material.Manufacturer)
     join c in db.Cups
     on new { t.MaterialId, t.ColorId } equals new { c.MaterialId, c.ColorId }
     where t.Id == id
     select new 
      {
         Teapot = t,
         Cup = c,
         Material = t.Material,
         Manufacturer = t.Material.Manufacturer,
      })
    .AsEnumerable()
    .Select(a => new ViewModel.Data.TeapotsWithInfo 
      { 
         Teapot = a.Teapot, 
         Cup = a.Cup 
      })
    .SingleOrDefault();
