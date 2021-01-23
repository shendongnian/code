    using (var db = new MyEntities()) {
      var user1 = new User();
      var user2 = new User();
      var user3 = new User();
      user1.Followers = new User[] { user2 };
      user2.Followers = new User[] { user3 };
      db.Users.Add(user1);
      db.SaveChanges();
    }
