    public ActionResult Add(string id_klasy)
    {
        var dataContext = db.Uczniowie;
        var ucz = dataContext.Where(m => m.KlasaId.Equals(id_klasy))
                             .Select(m => m.Nazwisko + " " + m.Imie);
        return View(ucz);
    }
