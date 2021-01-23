    public void AllocateUserRole(CommonLayer.User User, CommonLayer.Role Role)
    {
            User.Roles.Add(Role); // this does nothing to your Database. 
            
            //You should use this to add user to your context ( db )            
            this.Entities.Users.Add(User); 
            // or this if you want to update your user in your context ( db ).
            this.Entities.Set<CommonLayer.User>().Attach(User);
            this.Entities.Entry(User).State = EntityState.Modified;
            this.Entities.SaveChanges();
    }
