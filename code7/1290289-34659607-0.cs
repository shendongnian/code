    using (MicrosoftEntities context = new MicrosoftEntities())
    {
         USER user = new USER();
         user.FIRST_NAMES = "u";
         user.LAST_NAME = "u";
    
         /** Notice we don't specify a ROLE_ID here, we let EF generate it **/
         user.USER_ROLE.Add(new USER_ROLE() { role_name ="a" });
         user.USER_ROLE.Add(new USER_ROLE() { role_name ="b" });
         /** attach all entities to the context **/
         foreach(var role in user.USER_ROLE)
         {
           context.Entry(role).State = role.ROLE_ID == default(long) ? EntityState.Added : EntityState.Modified;
         }
         context.USERZs.Add(user);
         context.SaveChanges();
    }
