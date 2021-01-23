    // GET: Recipes/Details/5
    public ActionResult Details(int? id)
    {
        if (id == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        Recipe recipe = db.Recipes.Find(id);
        if (recipe == null)
        {
            return HttpNotFound();
        }
        return View(recipe);
    }
