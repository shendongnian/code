    public ActionResult DodajPrzedmiot()
        {
            if (StaticFunctions.IfLogged())
            {
                using (var db = new DatabaseContext())
                {
                    var cats = from b in db.Categories
                               select new { b.Kategoria };
    
                    var x = cats.ToList().Select(c => new SelectListItem
                    {
                        Text = c.Kategoria,
                        Value = c.Kategoria
                    }).ToList();
    
                    ViewBag.KategoriaList = x;
                }
                return View();
            }
            else
            {
                return RedirectToAction("Logowanie", "User");
            }
        }
