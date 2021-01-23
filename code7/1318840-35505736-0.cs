    var yourExistingQueryLogic = ...
                                 }).ToList();
    
    var yourUserDictionary = yourExistingQueryLogic
                             .Select(x=>new {x.UserId, UserName = x.UserName+ " (" + EncryptionUtility.DecryptString(a.CPR).Insert(6, "-") + ")"}) //you can simply build an anonymous object here
                             .Distinct() //this will eliminate duplicates
                             .ToDictionary(x=>x.UserId, x=>x.UserName); // DONE!
