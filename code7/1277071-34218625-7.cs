    foreach(var item in userView.UserUnits)
    {
         // get the mapped instance of UnitViewModel as Unit
         var userUnit = Mapper.Map<UnitViewModel, UserUnit>(item);
         user.Units.Add(userUnit);
    }
