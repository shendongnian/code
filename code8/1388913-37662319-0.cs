    var buses = new MyContext().Buses.Select(t => new SelectListItem()
    {
         Text = t.Sometext,
         Value = t.SomeValue
    }).ToList();
    buses.Add(new SelectListItem
    {
         Text = "--Select a Bus--",
         Value = "0",
         Selected = true
    });
    ViewBag.Drop = buses;
