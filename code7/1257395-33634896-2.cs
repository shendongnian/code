       public ActionResult GetWycieczkaDetails()
        {
            var id = Request["idWycieczka"];
            int selected = Int32.Parse(id);
            var wycieczkaDetails =
                db.Wycieczka_fakultatywna.Where(w => w.Id_wycieczki == selected).Select(x => new
                {
                    x.Opis,
                    x.Koszt
                });
        
            return Json(wycieczkaDetails.ToList(),JsonRequestBehavior.AllowGet);
        }
