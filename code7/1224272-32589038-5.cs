     var query= db.Researchers
                  .Where(r=>r.Submissions.Count>0)
                  .Select(r=>new {
                                   Name= r.FirstName + ' ' + r.Surname,
                                   NumberOfSubmissions= r.Submissions.Count 
                                 }
                         );
     return Json(query.ToList(), JsonRequestBehavior.AllowGet);
