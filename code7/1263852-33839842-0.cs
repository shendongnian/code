    public ActionResult Delete(int Id = 0)
        {           
            Register register;
            register = db.Registers.Find(Id);
            register.status = 1;
            db.Entry(register).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }       
