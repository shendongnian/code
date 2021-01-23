    foreach(var item in userView.UserUnits)
    {
         // get the mapped instance of UnitViewModel as Unit
         var userUnit= new UserUnit()
               {
                   Name = item.Name,
                   ...
               };
         user.Units.Add(userUnit);
    }
