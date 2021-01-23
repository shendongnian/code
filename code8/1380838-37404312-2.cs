    // GET: Admin/Details/5
    public ActionResult Details(int? id, string type) {
      //You do not want to do anything if you don't have type value too, so the condition
      if (id == null || string.IsNullOrEmpty(type)) {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      if(type=="drug"){
          Drug drug = db.Drugs.Find(id);
          if (drug == null) {
             return HttpNotFound();
          }
          return View(drug);
      }
      else
      {
          Food food = db.Foods.Find(id);
          if (food == null) {
             return HttpNotFound();
          }
          return View(food);
      }
    }
