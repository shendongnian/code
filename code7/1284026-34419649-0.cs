    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id, TeacherViewModel model)
    {
        var teacher = db.Teachers.Find(id);
        if (teacher == null)
        {
            return new HttpNotFoundResult();
        }
    
        if (ModelState.IsValid)
        {
            teacher.firstname = model.lastname;
            teacher.lastname = model.lastname;
            teacher.image = model.image;
            teacher.campusId = model.campusId;
    
            // Remove deselected skills
            teacher.skills.Where(m => !model.skillIds.Contains(m.Id))
                .ToList().ForEach(skill => teacher.skills.Remove(skill));
    
            // Add new skills
            var existingSkillIds = teacher.skills.Select(m => m.Id);
            db.Skills.Where(m => model.skillIds.Exclude(existingSkillIds).Contains(m.Id))
                .ToList().ForEach(skill => teacher.skills.Add(skill));
    
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    
        return View(model);
    }
