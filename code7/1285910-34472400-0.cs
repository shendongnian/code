    public int DeActivate(User entity) {
       try {
         using (UsersDataContext usersDC = new UsersDataContext()) {
           var user = usersDC.users.Single(x => x.id == entity.Id);
           user.active = false;
           usersDC.SubmitChanges();
           return 1;
         }
        } catch {
          return 0;
        }
       }
