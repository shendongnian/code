     using(var db=new dbContect()
      {
          var count=db.Countries.Where(x=>x.IsActive==true).Select(a=>new SelectListItem{
        Text=a.CountyName,
        Value=SqlFunctions.StringConvert(a.ID)
    }).ToList();
