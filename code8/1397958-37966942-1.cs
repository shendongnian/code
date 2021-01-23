    [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Edit(SiteImage siteimage, string AddXMap, string Save, int ImageOrder, int PageId, string RemoveXMap, int PageIdToRemove)
            {
    
    
                if (!String.IsNullOrEmpty(AddXMap))
                {
                    if (PageId > 0)
                    {
                        var xmapAdd = new MyLibrary.BLL.GetPageImageXMap();
                        xmapAdd.AddImageXMap(siteimage.ImageId, PageId, ImageOrder);
    
                        var imageQuery = new MyLibrary.BLL.GetImagesQuery();
                        siteimage = imageQuery.GetImage(siteimage.ImageId);
                    }
    
                }
    
                if (!String.IsNullOrEmpty(RemoveXMap))
                {
                    var xmapRemove = new MyLibrary.BLL.GetPageImageXMap();
                    xmapRemove.RemoveImageXMap(siteimage.ImageId, PageIdToRemove);
    
                    var imageQuery = new MyLibrary.BLL.GetImagesQuery();
                    siteimage = imageQuery.GetImage(siteimage.ImageId);
                }
    
                if (!String.IsNullOrEmpty(Save))
                {
                    if (ModelState.IsValid)
                    {
                        db.Entry(siteimage).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                }
                
                ViewBag.Pages = new SelectList(db.PageContents, "PageId", "PageTitle");
    
                return View(siteimage);
            }
