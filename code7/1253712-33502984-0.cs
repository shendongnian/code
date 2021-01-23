    public ActionResult TechKnowledgebaseList(Guid? createdBy)
    {
         string crBy = Guid.GetValueOrDefault(/*some default value or nothing*/).ToString();
         var model = db.Knowledgebases.AsQueryable();
    
         if (!string.IsNullOrEmpty(crBy)))
         {
              model = model.Where(c => c.CreatedBy.FullName == createdBy);
              ViewBag.CreatedBy = db.Users.Where(c => c.UserName.Equals(crBy)).First().FullName;
              ViewBag.CreatedBy = createdBy;
         }
         model = model.OrderBy(k => k.CreatedDate);
         var result = model.ToList();
    
         return View(result);
    }
