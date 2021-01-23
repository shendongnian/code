    // GET: Admin/Details/5
    public ActionResult Details(int? id, string type) {
      //You do not want to do anything if you don't have type value too, so the condition
      if (id == null || string.IsNullOrEmpty(type)) {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      var model=type=="drug"?db.Drugs.Find(id):db.Foods.Find('id');
      if (model == null) {
          return HttpNotFound();
      }
      return View(model);
    }
