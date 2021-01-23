    [HttpGet]
    public JsonResult GetAnimesOrdered(string search)
    {
        var animeTriees = db.Animes.Where(s => s.AnimeNom.ToLower().Contains(search)).ToList();
        return Json(animeTriees, JsonRequestBehavior.AllowGet);
    }
