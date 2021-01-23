    public void studentsGrid_DeleteItem(int studentID)
    {
        using (SchoolContext db = new SchoolContext())
        {
            var item = new Student { StudentID = studentID };
            db.Entry(item).State = EntityState.Deleted;
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                ModelState.AddModelError("", 
                  String.Format("Item with id {0} no longer exists in the database.", studentID));
            }
        }
    }
