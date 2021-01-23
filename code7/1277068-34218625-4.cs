    foreach(var item in userView.UserUnits)
    {
         // get the mapped instance of UnitViewModel as Unit
         var unit= Mapper.Map<UnitViewModel, Unit>(item);
         user.Units.Add(unit);
    }
