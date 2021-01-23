    public ActionResult List (DateTime startDate, DateTime endDate)
    {
        using(var db = new CardDBEntities())
        {
            var cards = (from c in db.Cards
                         join d in db.RegistrationDTs 
                         on c.CardId equals d.CardId
                         where d.RegistrationDateTime >= startDate && 
                               d.RegistrationDateTime <= endDate
                        select new ModelName
                        {
                            CardId = d.CardId,
                            Description = c.Description,
                            RegistrationDateTime = d.RegistrationDateTime
                        }).OrderByAscending(x => x.RegistrationDateTime)
                          .ToList();
            ViewData["cards"] = cards;
            
            return View();  
        }
    }
