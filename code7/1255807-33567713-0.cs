        [HttpPost]
                [ValidateAntiForgeryToken]
                public ActionResult Create([Bind(Include = "PojazdOgloszenieId,RodzajPaliwa,RokProdukcji,MocSilnika,Przebieg,DataPrzegladu,DataUbezpieczenia,OpisPojazdu")] Ogloszenie ogloszenie, HttpPostedFileBase file)
                {
                    if (ModelState.IsValid)
                    {
                        if (file != null)
                        {
                            var fileName = Path.GetFileName(file.FileName);
                            var path = Path.Combine(Server.MapPath("~/Zdjecia/"), fileName);
                            file.SaveAs(path);
                     
     ogloszenie.Zdjecie = Url.Content("~/Zdjecia/" + fileName);
    
                        }
        
                        db.Ogloszenia.Add(ogloszenie);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
        
                    ViewBag.PojazdOgloszenieId = new SelectList(db.Pojazdy, "ID", "Marka", ogloszenie.PojazdOgloszenieId);
                    return View(ogloszenie);
                }
