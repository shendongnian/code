    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(VR vR)
    {
        if (ModelState.IsValid)
        {
            var result = (from c in _context.MyVR.Where(c => c.ID == vR.ID) select c)
               .FirstOrDefault(); // use FirstOrDefault() to prevent an exception if the user changes you input for the ID.
            if (result != null)
            {
               result.FullName = vR.FullName;
               result.ModifiedBy = User.Identity.Name;
               result.Modified = DateTime.Now;
               _context.Update(result);
               _context.SaveChanges();
                return RedirectToAction("Index");
            }
        return View(vR);
    }
