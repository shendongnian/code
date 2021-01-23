    [HttpPost]
        public ActionResult DodajPrzedmiot(Item itm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    using (var db = new DatabaseContext())
                    {
                        // try putting this code in a separate function and use that function in both actions to populate the ViewBag.
                        var cats = from b in db.Categories
                                   select new { b.Kategoria };
        
                        var x = cats.ToList().Select(c => new SelectListItem
                        {
                            Text = c.Kategoria,
                            Value = c.Kategoria
                        }).ToList();
        
                        ViewBag.KategoriaList = x;
                        if (itm.Ilosc_zakupiona - itm.Ilosc_wypozyczona < 0) throw new ArgumentOutOfRangeException();
                        itm.Ilosc_magazynowa = itm.Ilosc_zakupiona - itm.Ilosc_wypozyczona;
                        db.Items.Add(itm);
                        db.SaveChanges();
                    }
                }
                catch (System.Data.Entity.Infrastructure.DbUpdateException)
                {
                    ViewBag.ErrorMessage = "Istnieje już przedmiot o takiej nazwie i/lub kodzie!";
                    return View();
                }
                catch (ArgumentOutOfRangeException)
                {
                    ViewBag.ErrorMessage = "Ilość zakupiona i/lub wypożyczona nie mogą być mniejsze od zera!";
                    return View();
                }
            }
            return View();
        }
