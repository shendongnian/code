    public ActionResult Item(int id) {
        using (ApplicationDbContext db = new ApplicationDbContext()) {
            Category model = db.Categories.Find(id);
            return View(model);
        }
    }
