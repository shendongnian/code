    IEnumerable<SelectListItem> TravelersList = db.Travelers
        .Where(c => c.TravelerId == ThisId).AsEnumerable().Select(x => new SelectListItem
    {
        Value = x.Id.ToString(),
        Text = string.Format("{0} {1}", x.Name, x.Destination)
    });
    ViewBag.Travelers = TravelersList;
