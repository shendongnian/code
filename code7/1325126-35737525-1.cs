    using (var db = new DbContext())
     {
        var tobedeletedrow = db.TableNames.FirstOrDefault(b => b.Id== Id);
        if (tobedeletedrow != null)
        {
            db.TableNames.Remove(tobedeletedrow);
            db.SaveChanges();
        }
     }
