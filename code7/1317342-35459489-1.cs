    using (MyEntity db = new MyEntity())
    {
        User u = db.Users.Find(userViewModel.ID);
        u.UserName = userViewModel.UserName;
        u.FullName = userViewModel.FullName;
        db.SaveChanges();
    }
