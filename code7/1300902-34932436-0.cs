    var query =
       from s in context.School
       from a in
       (
          from ssm in context.SchoolSocialMedia
          join d in context.Department on ssm.DepartmentId equals d.Id
          select new
          {
             ssm.SocialMediaTypeKey,
             ssm.Url,
             d.Name,
             d.ImportBusinessKey
          }
       ).DefaultIfEmpty()
       from ss in context.SchoolSocialMedia.Where(x => s.Id == x.SchoolId)
                                           .Where(x => a.SocialMediaTypeKey  == x.SocialMediaTypeKey)
                                           .DefaultIfEmpty()
       select new
       {
           s.Code, 
           s.Name, 
           Url = ss.Url ?? a.Url, 
           a.SocialMediaTypeKey
       }; 
