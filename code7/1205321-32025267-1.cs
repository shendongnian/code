    public ActionResult MyAction()
    {
         var model=new MyViewModel
         {
             MemberAdminOrMajors = Db.Members
                 .Where(m => m.MemberType == MemberTypeForReeve.BelediyeBaskani)
                 .OrderBy(m => m.Id)
                 .Select(m => new SelectListItem{ Text=m.Mail, Value=m.Id });
             
             MemberBMs= Db.Members
                 .Where(m => m.MemberType == MemberTypeForReeve.SahaElemanı)
                 .OrderBy(m => m.Id)
                 .Select(m => new SelectListItem{ Text=m.Mail, Value=m.Id });
            
             // collectiong other data
         }
         return View(model);
    } 
