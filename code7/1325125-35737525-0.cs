     using (var db = new DbContext())
     {
        var tobeupdatedrow = db.TableNames.FirstOrDefault(b => b.Id== Id);
        if (tobeupdatedrow != null)
        {
            tobeupdatedrow.tobeupdatedcolumn = "Some new value";
            db.SaveChanges();
        }
     }
