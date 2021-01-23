    ViewBag.HostID = new List<SelectListItem>()
    { 
        new SelectListItem()
        {
            Value = "-1", // note, do not make this "0" unless you make HostID nullable
            Text = "New Host"
        }
    }.Concat(db.Hosts.OrderBy(x => x.Name).Select(x => new SelectListItem()
    {
        Value = x.id.ToString(),
         Text = x.Name
    }));
