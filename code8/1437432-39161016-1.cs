    var AllVars = db.Users.GetType().GetProperties(
      System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
    foreach(var item in AllVars)
    {
      ViewBag.item.NameVariable = item.Name;
    }
