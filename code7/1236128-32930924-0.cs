    [HttpGet]
    public ActionResult Edit(int recordId)
    {
            using (var db = new  MitishaKitchenContext())
            {
                // fetch data for the image by Id
                var yourmodel = db.Images.Where(x => x.RecordId == recordId).FirstOrDefault();
    
                if(yourmodel != null)
                {
                     return View("Create", yourmodel);
                }
            }
            return RedirectToAction("Index");
    }
