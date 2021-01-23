    using(var db = new DbContext())
    {
        var p = db.Parents.First();
        var c = new Child();
        p.Children.Add(c);
        db.SaveChanges(); // Child was saved to the database
        p.Children.Remove(c);
        db.SaveChanges(); // Child will be deleted from the database
        p.Children.Clear();
        db.SaveChanges(); // All Child of this parent will be deleted
    }
       
