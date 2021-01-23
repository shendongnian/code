    public ActionResult Create([Bind(Include = "ID,Compagny,Website,Logo")] References references, HttpPostedFileBase ImagePath)
            {
                if (ModelState.IsValid)
                {
                    var fileName = Path.GetFileName(ImagePath.FileName);
                    references.ImagePath = "/Uploads/References/" + fileName;
                    ImagePath.SaveAs(Server.MapPath("~/Uploads/References/" + fileName));
    
                    db.References.Add(references);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
    
                return View(references);
            }
