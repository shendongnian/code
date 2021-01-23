    [HttpPost]
     public ActionResult IndexDropDown(ViewModelForHostBooster model)
        {
            if (!ModelState.IsValid)
            {
                ConfigureViewModel(model);
                return View(model);
            }
            else
            {
                HostBoostersDBEntities2 db = new HostBoostersDBEntities2();
                CalculatorPrice calculatePrice  =  db.CalculatorPrices
                    .Where(x => x.LeagueId == model.SelectedLeague
                        &&
                        x.LeagueDivisionId == model.SelectedLeagueDivision).FirstOrDefault();
                 if (calculatePrice != null)
                {
                    calculatePrice.LeagueId = (int)model.SelectedLeague;
                    calculatePrice.LeagueDivisionId = (int)model.SelectedLeagueDivision;
                    calculatePrice.Price = model.Price;
                    //db.Entry(calculatePrice).State = EntityState.Modified;
                    db.SaveChanges();
                }
                else
                {
                    calculatePrice = new CalculatorPrice();
                    calculatePrice.LeagueId = (int)model.SelectedLeague;
                    calculatePrice.LeagueDivisionId = (int)model.SelectedLeagueDivision;
                    calculatePrice.Price = model.Price;
                    db.CalculatorPrices.Add(calculatePrice);
                    db.SaveChanges();
                }
    
    
            }
            ConfigureViewModel(model);
            return View(model);
        }
