      [HttpGet]
      public ActionResult Search(string category) // <-- selected category
      {
        var myList = db.Images.ToList();
        if(!string.IsNullOrEmpty(category)){
              myList = db.Images.Where(s => s.Category == category).ToList();
        }
        
        return View(myList);
      }
