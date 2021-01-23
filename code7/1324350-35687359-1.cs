    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Create([Bind(Include = "Id,Name,Address,Description,Mail,Phone,Small_Description")] School school, HttpPostedFileBase Logo)
        {
            if (ModelState.IsValid)
            {
                using (var memoryStream = new MemoryStream())
                {
                    Logo.InputStream.CopyTo(memoryStream);
                    school.Logo = memoryStream.ToArray();
                }
                db.School.Add(school);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(school);
        }
    }
    
