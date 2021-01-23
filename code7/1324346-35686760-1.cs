    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Create([Bind(Include = "Id,Name,Address,Description,Mail,Phone,Small_Description")] School school)
    {
      if (ModelState.IsValid)
      {
            byte[] fileData = null;
            using (var binaryReader = new BinaryReader(Request.Files["logo"].InputStream))
            {
                fileData = binaryReader.ReadBytes(Request.Files["logo"].ContentLength);
            }
        school.Logo=fileData ;
        db.School.Add(school);
        await db.SaveChangesAsync();
        return RedirectToAction("Index");
      }
      return View(school);
    }
