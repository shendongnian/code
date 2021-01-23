     var query= db.Researchers
                  .Where(r=>r.ResearcherSubmissions.Count>0)// Researchers that have submissions
                  .Select(r=>new {
                                   Name= r.FirstName + ' ' + r.Surname,
                                   NumberOfSubmissions= r.ResearcherSubmissions.Count 
                                 }
                         );
     return Json(query.ToList(), JsonRequestBehavior.AllowGet);
