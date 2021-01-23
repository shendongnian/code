    var curDepId = "abcDep";
     var curUser=new User()
              {
                  UserID = "123",
                  UserName = "John cena",
                  UserTitle = "Champian",
                  UserExt = "7777",
                  UserIsAt = "Yes"
               };
    foreach (var d in dic)
    { 
        var curCompany=d.Value;
        if (curCompany == null || curCompany.Dep==null) continue;
        var depObj = curCompany.Dep.Where(c => c.DepID == curDepId).FirstOrDefault();
        if (depObj != null)
        { 
            if(depObj.User==null)
            {
             depObj.User=new List<User>();
            }
            depObj.User.Add(curUser);
            break;
        }
    }
