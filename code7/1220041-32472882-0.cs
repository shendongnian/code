    using(TempDBEntity context = new TempDBEntity())
    {
       var temp = context.Users.Where(m => m.user_unique_id == 1).FirstOrDefault();
       temp.timestamp = new DateTime();
       temp.AddLog("Login", context);
    }
