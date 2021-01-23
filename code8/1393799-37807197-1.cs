    string[] teamArray = query.Split(new char[] { ',' });
    for (int i = 0; i < teamArray.Count(); i++)
    {
       if (!teamArray[i].Contains(userName, StringComparison.OrdinalIgnoreCase))
       {
           return View("Unauthorized");
       }
    }
