    public void AllocateUserRole(CommonLayer.User User, CommonLayer.Role Role)
    {
            User.Roles.Add(Role); // this does nothing to your Database. 
            this.Entities.Users.Add(User); //instead you should use this to add user to your context ( db )
            this.Entities.Users.Update(User); // or this if you want to update your user in your context ( db ).
            this.Entities.SaveChanges();
    }
