    var buses = db.Buses.Select(t => new SelectListItem
    {
         Text = t.SomeText,
         Value = t.SomeValue
    }).ToList();
    buses.Add(new SelectListItem
    {
         Text = "--Select a Bus--",
         Value = "0",
         Selected = true
    });
    ViewBag.Drop = buses;
