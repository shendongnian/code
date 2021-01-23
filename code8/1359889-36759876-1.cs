    IEnumerable<ServiceVM> model = db.PS.GroupBy(x => x.Service).Select(x => new ServiceVM()
    {
        Name = x.Key,
        Offers = x.Select(y => new OfferVM()
        {
            ID = y.ID,
            Offer = y.Offer
        }
    });
    return View(model);
