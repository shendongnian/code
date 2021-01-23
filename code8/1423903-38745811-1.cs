    [HttpPost]
        public ActionResult DodajPrzedmiot(Item itm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    using (var db = new DatabaseContext())
                    {
                        if (itm.Ilosc_zakupiona - itm.Ilosc_wypozyczona < 0) throw new ArgumentOutOfRangeException();
                        itm.Ilosc_magazynowa = itm.Ilosc_zakupiona - itm.Ilosc_wypozyczona;
                        db.Items.Add(itm);
                        //db.Database.ExecuteSqlCommand("INSERT INTO Items(Nazwa_przedmiotu, Kategoria, Kod, Ilosc_ogolna, Ilosc_pozostala, Ilosc_wypozyczona, Wartosc, Sektor, Regal) VALUES({0},{1},{2},{3},{4},{5},{6},{7},{8},{9})", itm.Nazwa_przedmiotu, itm.Kategoria, itm.Kod, itm.Ilosc_ogolna, itm.Ilosc_pozostala, itm.Ilosc_wypozyczona, itm.Wartosc, itm.Sektor, itm.Regal);
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
