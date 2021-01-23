    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create([Bind(Include = "Id,Name")] ItemWithVersion itemWithVersion)
    {
        if (ModelState.IsValid)
        {
            // get the item with highest version
            ItemWithVersion item = db.ItemWithVersions.Where(i =>i.ItemNr == itemWithVersion.ItemNr).OrderByDescending(i => i.VersionNr).FirstOrDefault();
            //if item doesnt exist we need to create
            if(item == null)  {
               //get the last item with highest ItemNr
               ItemWithVersion lastitem = db.ItemWithVersions.OrderByDescending(i => i.ItemNr).FirstOrDefault();
               if(lastitem == null) {
                 //if we didnt find a item, it means is the first item in the DB
                 itemWithVersion.ItemNr = 1;
               } else {
                 //increment the itemNr for the new Item
                 itemWithVersion.ItemNr = lastitem.ItemNr + 1;
               }
               //set version to 1 since is the first version for this new ItemNr
               itemWithVersion.VersionNr = 1;
            } else {
                //if we found a item for the current ItemNr we increase the version for the new item
               itemWithVersion.VersionNr = item.VersionNr + 1;
            }
            db.ItemWithVersions.Add(itemWithVersion);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(itemWithVersion);
    }
