    using (MicrosoftEntities context = new MicrosoftEntities())
    using(var transaction = context.DataBase.BeginTransaction())
    {
     USER user = new USER();
     user.FIRST_NAMES = "u";
     user.LAST_NAME = "u";
     context.Users.Add(user);
     context.SaveChanges();
     user.USER_ROLE.Add(new USER_ROLE() { ROLE_ID = 10001, role_name ="a", userId = user.Id});
     user.USER_ROLE.Add(new USER_ROLE() { ROLE_ID = 10002, role_name ="b", userId = user.Id});
    
     context.SaveChanges();
     transaction.Commit();
    }
