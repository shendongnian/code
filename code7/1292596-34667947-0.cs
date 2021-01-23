    public ActionResult View(int? id)
    {
       if(id!=null)
       {
          int idToCheck= id.Value;
          // use int to get your entity/View model from db and then return view
       }
       return RedirectToAction("Index");
    }
