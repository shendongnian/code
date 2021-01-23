    foreach(var item in userView.UserUnits)
    {
         // get the mapped instance of UnitViewModel as Unit
         var unit= new Unit()
               {
                   Name = item.Name,
                   ...
               };
         user.Units.Add(unit);
    }
