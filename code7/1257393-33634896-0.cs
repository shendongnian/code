      public ActionResult Test()
        {
            var example = Request["SelectedWycieczka"];
            int id = Int32.Parse(example);
          var wycieczkaDetails = 
               db.Wycieczka_fakultatywna.Where(w => w.Id_wycieczki == id ).Select(x => new
               {
                   x.Id_wycieczki,
                   x.Opis,
                   x.Koszt
               });
   
            return Json(wycieczkaDetails.ToList(),JsonRequestBehavior.AllowGet);
        }
