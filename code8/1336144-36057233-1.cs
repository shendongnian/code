    using(MyDbContext db = new MyDbContext()) {
      Child child = db.Childs.Create();
      Parent parent = db.Parents.Create();
      child.Parent = parent;
    }
    db.SaveChanges();
    }
